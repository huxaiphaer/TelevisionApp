using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BBSTV
{
	public partial class LoginSalesDetails : ContentPage
	{

		public int Count = 0;
		public short Counter = 0;
		public int SlidePosition = 0;
		string heightList;
		int heightRowsList = 90;

		public string username;
		public LoginSalesDetails()
		{
			InitializeComponent();


			LocalDB local = new LocalDB();
			string USERNAME = local.GetUsernames();
			string AGENTNO = local.GetAgentNumber();
			string AGENTNAME = local.GetAgentName();
			string AGENTPHONE = local.GetAgentPhone();
			string AGENTEMAIL = local.GetAgentEmail();
			int AGENTRATING = local.GetAgentRating();

			// No_A = AgentNo;
			accountname_label.Text = AGENTNAME;

			//agentNumber_txtcell.Detail = AGENTNO;
			agentphone_txtcell.Detail = AGENTPHONE;
			agentemail_txtcell.Detail = AGENTEMAIL;
			agentrating_txtcell.Detail = "" + AGENTRATING;
			this.username = USERNAME;



			// Wraping the height of the TableView 





		}

		async void onMySalesInfo(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new RecordSales());
		}




		async void onMyClients(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new MyClients(username));
		}






	}
}
