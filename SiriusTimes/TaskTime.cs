using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusTimes
{
	public class TaskTime : IComparable<TaskTime>
	{
		public int ID { get; set; }
		public int Hour { get; set; }
		public int Minute { get; set; }

		public TaskTime()
		{

		}

		public TaskTime(DateTime time)
		{
			Hour = time.Hour;
			Minute = time.Minute;
		}

		public TaskTime(string timeString)
		{
			FromString(timeString);
		}

		public TaskTime(object value)
		{
			FromString(value.ToString());
		}

		// DateTime -> TaskTime
		public static implicit operator TaskTime(DateTime value)
		{
			return new TaskTime(value);
		}

		// TaskTime -> DateTime
		public static explicit operator DateTime(TaskTime value)
		{
			return value.ToDateTime;
		}

		// string -> TaskTime
		public static implicit operator TaskTime(string value)
		{
			return new TaskTime(value);
		}

		// TaskTime -> string
		public static explicit operator String(TaskTime value)
		{
			return value.ToString();
		}

		public int CompareTo(TaskTime that)
		{
			if (this.Hour < that.Hour) return -1;
			if (this.Hour == that.Hour)
			{
				if (this.Minute < that.Minute) return -1;
				if (this.Minute == that.Minute)
				{
					return 0;
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
				Hour = fromValue.Hour;
				Minute = fromValue.Minute;
			}
			catch { }
		}

		public override string ToString()
		{
			return String.Format("{0:00}:{1:00}", Hour, Minute);
		}
				
		public DateTime ToDateTime
		{
			get
			{
				return new DateTime(1970, 1, 1, Hour, Minute, 0);
			}
		}
	}
}
