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
	public partial class MyClients : ContentPage
	{
		public int Count = 0;
		public short Counter = 0;
		public int SlidePosition = 0;
		string heightList;
		int heightRowsList = 90;


		private HttpClient _client = new HttpClient();
		public ObservableCollection<MyClientsModal> myclients;
		//	public ObservableCollection<Trend> trends;
		string username;
		public MyClients(string Username)
		{
			InitializeComponent();

			MyClientsList(Username);
			this.username = Username;



		}




		public async void MyClientsList(string Username)
		{

			if (CrossConnectivity.Current.IsConnected)
			{

				try
				{
					//Activity indicator visibility on
					salesreport_activity_indicator.IsRunning = true;
					string Url = "http://bbs.eamobiledirectory.com/Mobile/MobileApi.aspx?Action=MyAssignments&unm=" + Username;
					var content = await _client.GetStringAsync(Url);
					var n = JsonConvert.DeserializeObject<List<MyClientsModal>>(content);

					myclients = new ObservableCollection<MyClientsModal>(n);

					MyClientslistView.ItemsSource = myclients;


					int i = myclients.Count;
					if (i > 0)
					{
						salesreport_activity_indicator.IsRunning = false;
					}
					i = (myclients.Count * heightRowsList);
					MyClientslistView.HeightRequest = i;



				}
				catch (Exception ey)
				{
					Debug.WriteLine("" + ey);
				}

			}

			else
			{
				MyClientslistView.IsVisible = false;
				await DisplayAlert("Alert ", "No internet Connection Please ", "Ok");



			}




		}

		async void OnSalesReport(object sender, System.EventArgs e)
		{

			MyClientsModal m = new MyClientsModal();
			int Assign_D = m.AssignmentD;
			await Navigation.PushAsync(new SalesReports(Assign_D, username));
		}
	}
}
