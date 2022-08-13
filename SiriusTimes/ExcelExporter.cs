using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;

namespace SiriusTimes
{
	public class ExcelExporter : IDisposable
	{
		public int CurrentRow { get { return m_currentRow; } }
		public int CurrentColumn { get { return m_currentColumn; } }

		public enum eBorderLocation
		{
			Left,
			Right,
			Top,
			Bottom
		}

		/// <summary>
		/// This enumeration is required so that the Excel dependency remains only on the GMS-Library project.
		/// </summary>
		public enum eBorderStyle
		{
			Dashed = ExcelBorderStyle.Dashed,
			Dotted = ExcelBorderStyle.Dotted,
			Double = ExcelBorderStyle.Double,
			Thick = ExcelBorderStyle.Thick,
			Thin = ExcelBorderStyle.Thin,
			None = ExcelBorderStyle.None,
		}

		private const int NOT_SET = -999;
		private const int BLACK = 1;
		private const int GRAY = 15;

		private int m_currentRow = 0;
		private int m_currentColumn = 1;
		private bool m_landscape = false;
		private string m_filename = string.Empty;

		private Collection<string> m_rowDetails = new Collection<string>();

		private ExcelPackage m_excelPackage = null;
		private ExcelWorksheet m_currentWorksheet = null;


		private class StyleInformation : ICloneable
		{
			public string Name;
			public string NumberFormat;
			public Nullable<ExcelHorizontalAlignment> HorizontalAlignment = null;
			public Nullable<ExcelVerticalAlignment> VerticalAlignment = null;
			public Nullable<bool> WrapText = null;
			public string FontName = null;
			public Nullable<bool> Bold = null;
			public Nullable<Color> BackgroundColour = null;
			public Nullable<ExcelFillStyle> FillPattern = null;
			public Nullable<ExcelBorderStyle> LeftBorder = null;
			public Nullable<ExcelBorderStyle> TopBorder = null;
			public Nullable<ExcelBorderStyle> BottomBorder = null;
			public Nullable<ExcelBorderStyle> RightBorder = null;

			public object Clone()
			{
				return this.MemberwiseClone();
			}
		}

		private StyleInformation[] m_styleBases = new StyleInformation[]
		{
			new StyleInformation() { Name = "StringLiteral", NumberFormat = "@", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "Decimal", NumberFormat = "#,##0.0", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "Integer", NumberFormat = "#,##0", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "DateLiteral", NumberFormat = "dd-mmm-yy;@", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "TimeLiteral", NumberFormat = "hh:mm:ss AM/PM;@", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "DateTimeLiteral", NumberFormat = "dd-mm-yyyy hh:mm:ss AM/PM;@", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "Currency", NumberFormat = @"\$#,##0;\-$#,##0;;@", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "CurrencyWithCents", NumberFormat = @"\$#,##0.00;\-$#,##0.00", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "DecimalFormula", NumberFormat = "#,##0.0", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "IntegerFormula", NumberFormat = "#,##0", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "CurrencyFormula", NumberFormat = @"\$#,##0;\-$#,##0;;@", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true },
			new StyleInformation() { Name = "CurrencyFormulaWithCents", NumberFormat = @"\$#,##0.00;\-$#,##0.00", VerticalAlignment = ExcelVerticalAlignment.Top, WrapText = true }
		};

		private List<string> m_stylesAddedToSpreadSheet = new List<string>();
		private Dictionary<string, StyleInformation> m_styleDictionary = new Dictionary<string, StyleInformation>();

		private void StyleAddLeft(ref StyleInformation style)
		{
			style.Name += "Left";
			style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
		}

		private void StyleAddCenter(ref StyleInformation style)
		{
			style.Name += "Center";
			style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
		}

		private void StyleAddRight(ref StyleInformation style)
		{
			style.Name += "Right";
			style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
		}

		private void StyleAddBold(ref StyleInformation style)
		{
			style.Name += "Bold";
			style.Bold = true;
		}

		private void StyleAddBorder(ref StyleInformation style)
		{
			style.Name += "Border";
			style.LeftBorder = ExcelBorderStyle.Thin;
			style.TopBorder = ExcelBorderStyle.Thin;
			style.RightBorder = ExcelBorderStyle.Thin;
			style.BottomBorder = ExcelBorderStyle.Thin;
		}

		private void StyleAddBackground(ref StyleInformation style)
		{
			style.Name += "Background";
			style.BackgroundColour = Color.LightGray;
			style.FillPattern = ExcelFillStyle.Solid;
		}

		/// <summary>
		/// Generate a dictionary of available styles and their configuration.
		/// </summary>
		private void SetUpStyleDictionary()
		{
			StyleInformation newStyle;
			ExcelHorizontalAlignment[] alignments = new ExcelHorizontalAlignment[]
			{
				ExcelHorizontalAlignment.Left,
				ExcelHorizontalAlignment.Center,
				ExcelHorizontalAlignment.Right
			};

			foreach (StyleInformation style in m_styleBases)
			{
				foreach (ExcelHorizontalAlignment alignment in alignments)
				{
					newStyle = (StyleInformation)style.Clone();

					switch (alignment)
					{
						case ExcelHorizontalAlignment.Left:
							StyleAddLeft(ref newStyle);
							m_styleDictionary.Add(newStyle.Name, (StyleInformation)newStyle.Clone());       // Left
							break;
						case ExcelHorizontalAlignment.Center:
							StyleAddCenter(ref newStyle);
							m_styleDictionary.Add(newStyle.Name, (StyleInformation)newStyle.Clone());       // Center
							break;
						case ExcelHorizontalAlignment.Right:
							StyleAddRight(ref newStyle);
							m_styleDictionary.Add(newStyle.Name, (StyleInformation)newStyle.Clone());       // Right
							break;
					}

					StyleInformation borderClone = (StyleInformation)newStyle.Clone();
					StyleInformation backgroundClone = (StyleInformation)newStyle.Clone();

					StyleAddBold(ref newStyle);                                 // [LCR]Bold
					m_styleDictionary.Add(newStyle.Name, (StyleInformation)newStyle.Clone());

					StyleInformation boldBackgroundClone = (StyleInformation)newStyle.Clone();

					StyleAddBorder(ref borderClone);                            // [LCR]Border
					m_styleDictionary.Add(borderClone.Name, (StyleInformation)borderClone.Clone());

					StyleAddBackground(ref borderClone);                        // [LCR]BorderBackground
					m_styleDictionary.Add(borderClone.Name, borderClone);

					StyleAddBackground(ref backgroundClone);                    // [LCR]Background
					m_styleDictionary.Add(backgroundClone.Name, backgroundClone);

					StyleAddBorder(ref newStyle);                               // [LCR]BoldBorder
					m_styleDictionary.Add(newStyle.Name, (StyleInformation)newStyle.Clone());

					StyleAddBackground(ref newStyle);                           // [LCR]BoldBorderBackground
					m_styleDictionary.Add(newStyle.Name, newStyle);

					StyleAddBackground(ref boldBackgroundClone);                // [LCR]BoldBackground
					m_styleDictionary.Add(boldBackgroundClone.Name, boldBackgroundClone);
				}
			}
		}

		private void SetStyleFromInformation(ExcelStyle rangeStyle, StyleInformation information)
		{
			rangeStyle.Font.Name = "Arial";
			rangeStyle.Font.Size = 10;
			rangeStyle.Numberformat.Format = information.NumberFormat;
			if (information.HorizontalAlignment.HasValue)
			{
				rangeStyle.HorizontalAlignment = information.HorizontalAlignment.Value;
			}
			if (information.VerticalAlignment.HasValue)
			{
				rangeStyle.VerticalAlignment = information.VerticalAlignment.Value;
			}
			if (information.WrapText.HasValue)
			{
				rangeStyle.WrapText = information.WrapText.Value;
			}
			if (information.FontName != null && information.FontName.Length > 0)
			{
				rangeStyle.Font.Name = information.FontName;
			}
			if (information.Bold.HasValue)
			{
				rangeStyle.Font.Bold = information.Bold.Value;
			}
			if (information.FillPattern.HasValue)
			{
				rangeStyle.Fill.PatternType = information.FillPattern.Value;

				if (information.BackgroundColour.HasValue)
				{
					rangeStyle.Fill.BackgroundColor.SetColor(information.BackgroundColour.Value);
				}
			}
			if (information.LeftBorder.HasValue)
			{
				rangeStyle.Border.Left.Style = information.LeftBorder.Value;
			}
			if (information.TopBorder.HasValue)
			{
				rangeStyle.Border.Top.Style = information.TopBorder.Value;
			}
			if (information.RightBorder.HasValue)
			{
				rangeStyle.Border.Right.Style = information.RightBorder.Value;
			}
			if (information.BottomBorder.HasValue)
			{
				rangeStyle.Border.Bottom.Style = information.BottomBorder.Value;
			}
		}

		private void SetStyleName(ExcelRange range, string styleName)
		{
			// Check to see if this style has been added to the spreadsheet.
			if (!m_stylesAddedToSpreadSheet.Contains(styleName))
			{
				// If the style exists in the defined collection then add it to the spreadsheet.
				if (m_styleDictionary.ContainsKey(styleName))
				{
					ExcelNamedStyleXml newStyle = m_excelPackage.Workbook.Styles.CreateNamedStyle(styleName);
					SetStyleFromInformation(newStyle.Style, m_styleDictionary[styleName]);
				}

				// Record the we have seen the style even if it is not added to the spreadsheet.
				m_stylesAddedToSpreadSheet.Add(styleName);
			}

			range.StyleName = styleName;
		}


		/// <summary>
		/// Opens the Excel application and prepares a workbook with a single sheet.
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="sheetName"></param>
		/// <param name="title"></param>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <param name="landscape"></param>
		/// <param name="columnWidths"></param>
		public ExcelExporter(string filename, string sheetName, string title, string left, string right, bool landscape,
								List<float> columnWidths, string footerLeft = "", string footerRight = "")
		{
			m_filename = filename;

			SetUpStyleDictionary();

			m_landscape = landscape;

			if (File.Exists(m_filename))
			{
				File.Delete(m_filename);
			}
			FileInfo newFile = new FileInfo(m_filename);

			m_excelPackage = new ExcelPackage(newFile);
			m_currentWorksheet = m_excelPackage.Workbook.Worksheets.Add(sheetName);

			m_currentWorksheet.HeaderFooter.OddHeader.LeftAlignedText = "&14" + left;
			m_currentWorksheet.HeaderFooter.OddHeader.CenteredText = "&14" + title;
			m_currentWorksheet.HeaderFooter.OddHeader.RightAlignedText = "&14" + right;
			m_currentWorksheet.HeaderFooter.OddFooter.LeftAlignedText = "&14" + footerLeft;
			m_currentWorksheet.HeaderFooter.OddFooter.CenteredText = "&14" + "Page &P of &N";
			m_currentWorksheet.HeaderFooter.OddFooter.RightAlignedText = "&14" + footerRight;

			if (landscape)
			{
				m_currentWorksheet.PrinterSettings.Orientation = eOrientation.Landscape;
				m_currentWorksheet.PrinterSettings.FitToWidth = 1;
			}
			m_currentWorksheet.PrinterSettings.FitToPage = true;
			m_currentWorksheet.PrinterSettings.FitToHeight = 99;
			m_currentWorksheet.PrinterSettings.ShowGridLines = true;

			m_currentWorksheet.DefaultColWidth = 14;

			for (int index = 0; index < columnWidths.Count; index++)
			{
				m_currentWorksheet.Column(index + 1).Width = columnWidths[index];
			}
		}

		public void AddWorkSheet(string sheetName, string title, string left, string right, bool landscape,
									List<float> columnWidths, string footerLeft = "", string footerRight = "")
		{
			m_currentRow = 0;
			m_currentColumn = 1;
			m_landscape = landscape;

			m_currentWorksheet = m_excelPackage.Workbook.Worksheets.Add(sheetName);

			m_currentWorksheet.HeaderFooter.OddHeader.LeftAlignedText = left;
			m_currentWorksheet.HeaderFooter.OddHeader.CenteredText = title;
			m_currentWorksheet.HeaderFooter.OddHeader.RightAlignedText = right;
			m_currentWorksheet.HeaderFooter.OddFooter.LeftAlignedText = footerLeft;
			m_currentWorksheet.HeaderFooter.OddFooter.CenteredText = "Page &P of &N";
			m_currentWorksheet.HeaderFooter.OddFooter.RightAlignedText = footerRight;

			if (landscape)
			{
				m_currentWorksheet.PrinterSettings.Orientation = eOrientation.Landscape;
			}
			m_currentWorksheet.PrinterSettings.FitToPage = true;
			m_currentWorksheet.PrinterSettings.FitToHeight = 99;
			m_currentWorksheet.PrinterSettings.ShowGridLines = true;

			m_currentWorksheet.DefaultColWidth = 14;

			for (int index = 0; index < columnWidths.Count; index++)
			{
				m_currentWorksheet.Column(index + 1).Width = columnWidths[index];
			}
		}

		public void SetHeaderMargin(int margin)
		{
			m_currentWorksheet.PrinterSettings.TopMargin = margin;
			//m_currentWorksheet.PrinterSettings.HeaderMargin = margin;
		}

		public void Dispose()
		{
			if (m_excelPackage != null)
			{
				m_excelPackage.Dispose();
			}
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Finish()
		{
			m_excelPackage.Save();
			/*
			System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
			myProcess.StartInfo.FileName = "Excel.exe";
			myProcess.StartInfo.Arguments = "\"" + m_filename + "\"";
			myProcess.StartInfo.UseShellExecute = true;
			myProcess.Start();
			*/
		}

		public void AddRow()
		{
			m_currentRow++;
			m_currentColumn = 1;
		}

		public void AddText(string text, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddText(text, numberOfColumns, bold, border, background, align, Color.White);
		}

		public void AddText(string text, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align, Color backgroundColour)
		{
			AddCell("System.String", text, numberOfColumns, bold, border, background, align, backgroundColour);

			m_currentColumn += numberOfColumns;
		}

		public void AddDate(object date, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("DateOnly", date, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddTime(object time, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("TimeOnly", time, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddDateTime(object dateTime, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("System.DateTime", dateTime, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddInteger(object intValue, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("System.Int32", intValue, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddDecimal(object decimalValue, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("System.Decimal", decimalValue, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddBoolean(object boolValue, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("System.Boolean", boolValue, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddCurrency(object currencyValue, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align, bool includeCents = false)
		{
			if (includeCents)
			{
				AddCell("CurrencyWithCents", currencyValue, numberOfColumns, bold, border, background, align);
			}
			else
			{
				AddCell("Currency", currencyValue, numberOfColumns, bold, border, background, align);
			}

			m_currentColumn += numberOfColumns;
		}

		public void AddDecimalFormula(string formula, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("DecimalFormula", formula, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddIntegerFormula(string formula, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell("IntegerFormula", formula, numberOfColumns, bold, border, background, align);

			m_currentColumn += numberOfColumns;
		}

		public void AddCurrencyFormula(string formula, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align, bool includeCents = false)
		{
			if (includeCents)
			{
				AddCell("CurrencyFormulaWithCents", formula, numberOfColumns, bold, border, background, align);
			}
			else
			{
				AddCell("CurrencyFormula", formula, numberOfColumns, bold, border, background, align);
			}

			m_currentColumn += numberOfColumns;
		}

		private void AddCell(string cellDataType, object cellValue, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align)
		{
			AddCell(cellDataType, cellValue, numberOfColumns, bold, border, background, align, Color.White);
		}
		private void AddCell(string cellDataType, object cellValue, int numberOfColumns, bool bold, bool border, bool background, HorizontalAlignment align, Color backgroundColour)
		{
			string styleSuffix = string.Empty;
			DateTime xmlDate = DateTime.MinValue;
			ExcelRange currentCell = m_currentWorksheet.Cells[m_currentRow, m_currentColumn];
			ExcelRange currentRange = m_currentWorksheet.Cells[m_currentRow, m_currentColumn, m_currentRow, m_currentColumn + numberOfColumns - 1];

			switch (align)
			{
				case HorizontalAlignment.Left:
					styleSuffix = "Left";
					break;
				case HorizontalAlignment.Center:
					styleSuffix = "Center";
					break;
				case HorizontalAlignment.Right:
					styleSuffix = "Right";
					break;
			}
			if (bold)
			{
				styleSuffix += "Bold";
			}
			if (border)
			{
				styleSuffix += "Border";
			}
			if (background)
			{
				styleSuffix += "Background";
			}

			if (numberOfColumns > 1)
			{
				currentRange.Merge = true;
			}

			switch (cellDataType)
			{
				case "System.String":
					string XMLstring = string.Empty;

					if (cellValue != null && cellValue != DBNull.Value)
					{
						XMLstring = cellValue.ToString();
					}
					XMLstring = XMLstring.Trim();

					SetStyleName(currentRange, "StringLiteral" + styleSuffix);
					currentCell.Value = XMLstring;
					break;

				case "System.DateTime":
					// Excel has a specific Date Format of YYYY-MM-DD followed by  
					// the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
					if (cellValue != null && cellValue != DBNull.Value)
					{
						xmlDate = (DateTime)cellValue;
					}

					SetStyleName(currentRange, "DateTimeLiteral" + styleSuffix);

					if (xmlDate != DateTime.MinValue)
					{
						currentCell.Value = xmlDate;
					}
					break;

				case "DateOnly":
					// Excel has a specific Date Format of YYYY-MM-DD.
					if (cellValue != null && cellValue != DBNull.Value)
					{
						xmlDate = (DateTime)cellValue;
					}

					SetStyleName(currentRange, "DateLiteral" + styleSuffix);

					if (xmlDate != DateTime.MinValue)
					{
						currentCell.Value = xmlDate;
					}
					break;

				case "TimeOnly":
					// Excel has a specific Date Format of YYYY-MM-DD followed by  
					// the letter 'T' then hh:mm:sss.lll For some reason, a value of
					// 1899-12-31Thh:mm:ss is treated as time only!!
					if (cellValue != null && cellValue != DBNull.Value)
					{
						xmlDate = (DateTime)cellValue; ;
					}

					SetStyleName(currentRange, "TimeLiteral" + styleSuffix);

					if (xmlDate != DateTime.MinValue)
					{
						currentCell.Value = xmlDate;
					}
					break;

				case "Currency":
					SetStyleName(currentRange, "Currency" + styleSuffix);
					if (cellValue != null && cellValue != DBNull.Value)
					{
						currentCell.Value = Convert.ToInt32(cellValue);
					}
					else
					{
						currentCell.Value = 0;
					}
					break;

				case "CurrencyWithCents":
					SetStyleName(currentRange, "CurrencyWithCents" + styleSuffix);
					if (cellValue != null && cellValue != DBNull.Value)
					{
						currentCell.Value = Convert.ToSingle(cellValue);
					}
					else
					{
						currentCell.Value = 0;
					}
					break;

				case "System.Boolean":
					SetStyleName(currentRange, "StringLiteral" + styleSuffix);
					if (cellValue != null && cellValue != DBNull.Value)
					{
						currentCell.Value = cellValue.ToString();
					}
					break;

				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
				case "System.Byte":
					SetStyleName(currentRange, "Integer" + styleSuffix);
					if (cellValue != null && cellValue != DBNull.Value)
					{
						currentCell.Value = cellValue;
					}
					else
					{
						currentCell.Value = 0;
					}
					break;

				case "System.Decimal":
				case "System.Double":
					SetStyleName(currentRange, "Decimal" + styleSuffix);
					if (cellValue != null && cellValue != DBNull.Value)
					{
						currentCell.Value = cellValue;
					}
					else
					{
						currentCell.Value = 0;
					}
					break;

				case "System.DBNull":
					SetStyleName(currentRange, "StringLiteral" + styleSuffix);
					break;

				case "DecimalFormula":
					SetStyleName(currentRange, "DecimalFormula" + styleSuffix);
					currentCell.FormulaR1C1 = cellValue.ToString();
					break;

				case "IntegerFormula":
					SetStyleName(currentRange, "IntegerFormula" + styleSuffix);
					currentCell.FormulaR1C1 = cellValue.ToString();
					break;

				case "CurrencyFormula":
					SetStyleName(currentRange, "CurrencyFormula" + styleSuffix);
					currentCell.FormulaR1C1 = cellValue.ToString();
					break;

				case "CurrencyFormulaWithCents":
					SetStyleName(currentRange, "CurrencyFormulaWithCents" + styleSuffix);
					currentCell.FormulaR1C1 = cellValue.ToString();
					break;

				default:
					throw (new Exception(cellDataType + " not handled."));
			}

			if (backgroundColour != Color.White)
			{
				currentRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
				currentRange.Style.Fill.BackgroundColor.SetColor(backgroundColour);
			}
		}

		public void AddBorder(string range, eBorderLocation location, eBorderStyle lineStyle)
		{
			switch (location)
			{
				case eBorderLocation.Left:
					m_currentWorksheet.Cells[range].Style.Border.Left.Style = (ExcelBorderStyle)lineStyle;
					break;
				case eBorderLocation.Right:
					m_currentWorksheet.Cells[range].Style.Border.Right.Style = (ExcelBorderStyle)lineStyle;
					break;
				case eBorderLocation.Top:
					m_currentWorksheet.Cells[range].Style.Border.Top.Style = (ExcelBorderStyle)lineStyle;
					break;
				case eBorderLocation.Bottom:
					m_currentWorksheet.Cells[range].Style.Border.Bottom.Style = (ExcelBorderStyle)lineStyle;
					break;
			}
		}

		public void AddUnderline(string range)
		{
			m_currentWorksheet.Cells[range].Style.Font.UnderLine = true;
		}

		public void SetPrintArea(string range)
		{
			m_currentWorksheet.PrinterSettings.PrintArea = null;
			m_currentWorksheet.PrinterSettings.FitToPage = true;
			m_currentWorksheet.PrinterSettings.FitToWidth = 1;
			m_currentWorksheet.PrinterSettings.FitToHeight = 0;
			m_currentWorksheet.PrinterSettings.PrintArea = m_currentWorksheet.Cells[range];
		}

	}
}
