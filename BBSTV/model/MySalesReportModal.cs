using System;
namespace BBSTV
{
	public class MySalesReportModal
	{
		public int ID { get; set; }
		public int assignID { get; set; }
		public DateTime reportDate { get; set; }
		public string ReportDetails { get; set; }
		public DateTime? nextAppointedDate { get; set; }
		public object agent_name { get; set; }
		public object client_name { get; set; }
		public string saleStatus { get; set; }
		public string SupervisorComments { get; set; }
		public string f_report_date { get; set; }
		public string f_appoi_date { get; set; }
	}
}
