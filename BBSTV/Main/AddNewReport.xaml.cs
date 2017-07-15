using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace BBSTV
{
	public partial class AddNewReport : ContentPage
	{

		HttpClient client = new HttpClient();
		int ASSIGNID;
		string USERNAME;
		public AddNewReport(int AssignID, string username)
		{
			InitializeComponent();

			ASSIGNID = AssignID;
			USERNAME = username;



		}

		void OnSubmitReport(object sender, System.EventArgs e)
		{
			PostData();
		}





		public async void PostData()
		{

			string details = report_details_entry.Text;
			string date = nextappointment_entry.Text;

			addnew_activity_indicator.IsRunning = true;
			var url = string.Format("http://bbs.eamobiledirectory.com/Mobile/MobileApi.aspx?Action=NewSalesReport&unm={0}&assignID={1}&report_details={2}&appoi_date={3}",
					USERNAME,
					ASSIGNID,
					details,
					date);

			var response = await client.PostAsync(url, null);

			var responseContent = await response.Content.ReadAsStringAsync();
			addnew_activity_indicator.IsRunning = false;
			report_details_entry.Text = "";
			nextappointment_entry.Text = "";

			await DisplayAlert("", "" + responseContent, "Ok");

		}



	}
}
