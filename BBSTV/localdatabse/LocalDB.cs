using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;



namespace BBSTV
{
	public class LocalDB
	{
		private SQLiteConnection _connection;

		public LocalDB()
		{
			_connection = DependencyService.Get<ISQLite>().GetConnection();
			_connection.CreateTable<UserModel>();
			_connection.CreateTable<UserDetailsModel>();
		}

		public IEnumerable<UserModel> GetTweets()
		{
			return (from t in _connection.Table<UserModel>()
					select t).ToList();
		}

		public UserModel GetUser(int id)
		{
			return _connection.Table<UserModel>().FirstOrDefault(t => t.ID == id);
		}

		public string GetUsernames()
		{
			List<UserModel> list = _connection.Query<UserModel>("Select username From [UserModel]");
			return list[0].username.ToString();

		}
		// Adding users details into sqlite 
		public void AddDetails(string username, string number, string agentname, string agentphone, string agentemail, int rating)
		{
			/*
			_connection.Query<UserModel>("Update [UserModel] set username='" + username + "',agentnumber='" + number + "'," +
										 "agentname='" + agentname + "',agentphone='" + agentphone + "'," +
										 "agentemail='" + agentemail + "',rating='" + rating + "'  where ID='" + "1" + "'");
										 */
			_connection.Query<UserDetailsModel>("Insert into [UserDetailsModel] (username, agentnumber, agentname,agentphone,agentemail,rating) values" +
			                             "('" + username + "','" + number + "','" + agentname + "','" + agentphone + "','"+agentemail+"','"+rating+"')");


		}

	


		//retriving the agentNumber 
		public string GetAgentNumber()
		{
			List<UserDetailsModel> list = _connection.Query<UserDetailsModel>("Select agentnumber From [UserDetailsModel]");
			return list[0].agentnumber.ToString();

		}

		//retrieving agent name .
		public string GetAgentName()
		{
			List<UserDetailsModel> list = _connection.Query<UserDetailsModel>("Select agentname From [UserDetailsModel]");
			return list[0].agentname.ToString();
		}
		// retrieving agent phone
		public string GetAgentPhone()
		{
			List<UserDetailsModel> list = _connection.Query<UserDetailsModel>("Select agentphone From [UserDetailsModel]");
			return list[0].agentphone.ToString();
		}

		//retrieving agentemail
		public string GetAgentEmail()
		{
			List<UserDetailsModel> list = _connection.Query<UserDetailsModel>("Select agentemail From [UserDetailsModel]");
			return list[0].agentemail.ToString();
		}

		//retrieving rating 
		public int GetAgentRating()
		{
			List<UserDetailsModel> list = _connection.Query<UserDetailsModel>("Select rating From [UserDetailsModel]");
			return list[0].rating;
		}



		// delete user 
		public void DeleteUser(int id)
		{
			_connection.Delete<UserModel>(id);
		}

		public void AddUser(string message)
		{
			var newTweet = new UserModel
			{
				username = message,
				CreatedOn = DateTime.Now
			};

			_connection.Insert(newTweet);
		}
	}
}

