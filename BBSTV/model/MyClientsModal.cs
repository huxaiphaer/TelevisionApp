using System;
namespace BBSTV
{
	public class MyClientsModal
	{
		public int ID { get; set; }
		public string client_name { get; set; }
		public string client_address { get; set; }
		public double longitude { get; set; }
		public int lattitude { get; set; }
		public string client_phone { get; set; }
		public string client_email { get; set; }
		public int client_biz_volume { get; set; }
		public int AssignmentD { get; set; }
		public string agent_no { get; set; }
		public int client_ID { get; set; }
		public DateTime startDate { get; set; }
		public object endDate { get; set; }
		public string AssignStatus { get; set; }
		public string assignmentComments { get; set; }
	}
}
