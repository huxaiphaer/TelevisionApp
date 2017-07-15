using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace BBSTV
{
	public partial class LoginSales : ContentPage
	{

		HttpClient client = new HttpClient();
		private static ISettings AppSettings =>
		CrossSettings.Current;

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
		public static bool OnLoggedIn(string key) =>
		AppSettings.GetValueOrDefault("login" + key, true);

		public async void onLogingingIn(object sender, System.EventArgs e)
		{

			using (var client_ = new HttpClient())
			{
				string Usename_ = username.Text.ToString();
				string Password = password.Text.ToString();


				//	try
				//	{



				activity_i_sales_logining.IsRunning = true;
				string url = "http://bbs.eamobiledirectory.com/Mobile/MobileApi.aspx?Action=Login&unm=" + Usename_ + "&upass=" + Password;
				string response = await client_.GetStringAsync(url);
				var logindetails = JsonConvert.DeserializeObject<Login>(response.Replace("[", "").Replace("]", ""));
				string Usnmae = logindetails.username;
				string AgentName = logindetails.agentName;
				string AgentPhone = logindetails.agent_phone;
				string AgentEmail = logindetails.agent_email;
				string  AgentNumber = logindetails.agentNo;
				int Agentrating = logindetails.agent_rating;

				LocalDB local = new LocalDB();
				local.AddDetails(Usename_, AgentNumber, AgentName, AgentPhone, AgentEmail, Agentrating);

				if (Usnmae != null)

				{

					//local.AddUser(Usename_);
					await Navigation.PushAsync(new LoginSalesDetails());
					activity_i_sales_logining.IsRunning = false;

				}

				else
				{
					OnLoggedIn(Usnmae);
					await DisplayAlert("Alert ", "Invalid Password or Username Please try Again :-(", "OK");
					activity_i_sales_logining.IsRunning = false;
					password.Text = "";
				}



				//}

				/*
				catch (System.NullReferenceException ey)
				{
					await DisplayAlert("Alert ", "There's a problem , while logging in", "OK");
					activity_i_sales_logining.IsRunning = false;
					password.Text = "";
					Debug.WriteLine("My Error "+ ey);
				}
				*/


			}

		}


	}
}
