using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusTimes
{
	public class TimesheetRecord
	{
		public int ID { get; set; }
		public string Client { get; set; }
		public string Project { get; set; }
		public TaskDate TaskDate { get; set; }
		public string TaskTitle { get; set; }
		public TaskTime StartTime { get; set; }
		public TaskTime EndTime { get; set; }
	}
}
