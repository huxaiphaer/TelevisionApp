using System;
using SQLite.Net.Attributes;

namespace BBSTV
{
	public class UserModel
	{


		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string username { get; set; }
		public DateTime CreatedOn { get; set; }
		public string agentname { get; set; }
		public string agentnumber { get; set; }
		public string agentphone { get; set; }
		public string agentemail { get; set; }
		public int rating { get; set; }

		public UserModel()
		{
		}
	}
}
