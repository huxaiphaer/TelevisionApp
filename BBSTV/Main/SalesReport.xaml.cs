using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace BBSTV
{
	public partial class SalesReport : ContentPage
	{


		public int Count = 0;
		public short Counter = 0;
		public int SlidePosition = 0;
		string heightList;
		int heightRowsList = 90;


		private HttpClient _client = new HttpClient();
		public ObservableCollection<MySalesReportModal> myclients;
		string USERNAME;
		int ASSIGNID;

		public SalesReport(int AssignD, string username)
		{
			InitializeComponent();

			ASSIGNID = AssignD;
			USERNAME = username;

			MySalesReportsList(AssignD, username);

		}


		// Toolbar icon 
		async void OnAdd(object sender, System.EventArgs e)
		{



			await Navigation.PushAsync(new AddNewReport(ASSIGNID, USERNAME));
		}








		public async void MySalesReportsList(int ID, string Username)
		{

			if (CrossConnectivity.Current.IsConnected)
			{

				try
				{
					//Activity indicator visibility on
					sp_activity_indicator.IsRunning = true;
					//http://bbs.eamobiledirectory.com/Mobile/MobileApi.aspx?Action=SalesReports&unm=sheila&assignID=1
					string Url = "http://bbs.eamobiledirectory.com/Mobile/MobileApi.aspx?Action=SalesReports&unm=" + Username + "&assignID=" + ID;
					var content = await _client.GetStringAsync(Url);
					var n = JsonConvert.DeserializeObject<List<MySalesReportModal>>(content);

					myclients = new ObservableCollection<MySalesReportModal>(n);

					SalesReportslistView.ItemsSource = myclients;


					int i = myclients.Count;
					if (i > 0)
					{
						sp_activity_indicator.IsRunning = false;
					}
					i = (myclients.Count * heightRowsList);
					SalesReportslistView.HeightRequest = i;



				}
				catch (Exception ey)
				{
					Debug.WriteLine("" + ey);
				}

			}

			else
			{
				SalesReportslistView.IsVisible = false;
				await DisplayAlert("Alert ", "No internet Connection Please ", "Ok");



			}


		}
	}
}
