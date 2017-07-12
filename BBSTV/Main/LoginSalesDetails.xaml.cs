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
		public LoginSalesDetails(string Username,  string AgentNo, string AgentName, string AgentPhone, string AgentEmail, int AgentRating)
		{
			InitializeComponent();


			// No_A = AgentNo;
			accountname_label.Text = AgentName;

			agentNumber_txtcell.Detail = AgentNo;
			agentphone_txtcell.Detail = AgentPhone;
			agentemail_txtcell.Detail = AgentEmail;
			agentrating_txtcell.Detail = "" + AgentRating;
			this.username = Username;

		

			// Wraping the height of the TableView 





		}





		async void onMyClients(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new MyClients(username));
		}






	}
}
