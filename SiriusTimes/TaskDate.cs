using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusTimes
{
	public class TaskDate : IComparable<TaskDate>
	{
		public int ID { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }

		public TaskDate()
		{

		}

		public TaskDate(DateTime date)
		{
			Year = date.Year;
			Month = date.Month;
			Day = date.Day;
		}

		public static implicit operator TaskDate(DateTime value)
		{
			return new TaskDate(value);
		}

		public int CompareTo(TaskDate that)
		{
			if (this.Year < that.Year) return -1;
			if (this.Year == that.Year)
			{
				if (this.Month < that.Month) return -1;
				if (this.Month == that.Month)
				{
					if (this.Day < that.Day) return -1;
					if (this.Day == that.Day)
					{
						return 0;
					}
					return 1;
				}
				return 1;
			}
			return 1;
		}

		public void FromString(string value)
		{
			try
			{
				DateTime fromValue = Convert.ToDateTime(value);
				Year = fromValue.Year;
				Month = fromValue.Month;
				Day = fromValue.Day;
			}
			catch { }
		}

		public override string ToString()
		{
			return String.Format("{0:00}-{1:00}-{2:0000}", Day, Month, Year);
		}

		public DateTime ToDateTime
		{
			get
			{
				return new DateTime(Year, Month, Day, 0, 0, 0);
			}
		}
	}
}
