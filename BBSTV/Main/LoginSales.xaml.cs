using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace BBSTV
{
	public partial class LoginSales : ContentPage
	{

		HttpClient client = new HttpClient();
		public LoginSales()
		{
			InitializeComponent();
		}




		/*
		public async void onLogingingIn(object sender, System.EventArgs e)
		{




			await Navigation.PushAsync(new LoginSalesDetails());
		}

*/

		public async void onLogingingIn(object sender, System.EventArgs e)
		{

			using (var client_ = new HttpClient())
			{
				string Usename_ = username.Text.ToString();
				string Password = password.Text.ToString();


				try
				{

					activity_i_sales_logining.IsRunning = true;
					string url = "http://bbs.eamobiledirectory.com/Mobile/MobileApi.aspx?Action=Login&unm=" + Usename_ + "&upass=" + Password;
					string response = await client_.GetStringAsync(url);

					var logindetails = JsonConvert.DeserializeObject<Login>(response.Replace("[", "").Replace("]", ""));
					var Usnmae = logindetails.username;
					var AgentName = logindetails.agentName;
					var AgentPhone = logindetails.agent_phone;
					var AgentEmail = logindetails.agent_email;
					var AgentNumber = logindetails.agentNo;
					var Agentrating = logindetails.agent_rating;

					if (Usnmae != null)
					{
						await Navigation.PushAsync(new LoginSalesDetails(Usename_, AgentNumber, AgentName, AgentPhone, AgentEmail, Agentrating));
						activity_i_sales_logining.IsRunning = false;
					}

					else
					{
						await DisplayAlert("Alert ", " Invalid Password or Username Please try Again :-(", "OK");
						activity_i_sales_logining.IsRunning = false;
						password.Text = "";
					}



				}

				catch (System.NullReferenceException ey)
				{
					await DisplayAlert("Alert ", " Invalid Password or Username Please try Again :-(", "OK");
					activity_i_sales_logining.IsRunning = false;
					password.Text = "";
				}


			}

		}


	}
}
