using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Xamarin.Forms;

namespace BBSTV
{
	public partial class OnlineStreaming : ContentPage
	{


		// private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
		private const string Url = "http://eamobiledirectory.com/cooperp/Mobile/Mobileapi.aspx?Action=Featured&Country=Uganda";
		private const string BaseImageUrl = "http://eamobiledirectory.com/cooperp/Images/app_images/";
		private HttpClient _client = new HttpClient();
		public ObservableCollection<Adverts> adverts;
		public int Count = 0;
		public short Counter = 0;
		public int SlidePosition = 0;
		//string heightList;
		//int heightRowsList = 90;

		public OnlineStreaming()
		{
			InitializeComponent();

			//this.Appearing += MainPage_Appearing;

		}





		/*
		private void MainPage_Appearing(object sender, EventArgs e)
		{

			try
			{
				Device.OpenUri(new Uri("http://video.ch9.ms/ch9/334f/891b78a5-642d-40b4-8d02-ff40ffdd334f/LoginToLinkedinUSingXamarinAuth_mid.mp4"));
				if (Media.CurrentState != InTheHand.Forms.MediaElementState.Playing)
				{
					Media.Play();
				}

			}
			catch (Exception ex)
			{

				Debug.WriteLine("" + ex);
			}
		}*/





		protected override async void OnAppearing()
		{
			if (CrossConnectivity.Current.IsConnected)
			{

				try
				{

					online_activity_indicator.IsRunning = true;
					var content = await _client.GetStringAsync(Url);
					var adv = JsonConvert.DeserializeObject<List<Adverts>>(content);

					adverts = new ObservableCollection<Adverts>(adv);

					OnlineAdvertsCarousel.ItemsSource = adverts;
					// attaching auto sliding on to carouselView 
					Device.StartTimer(TimeSpan.FromSeconds(10), () =>
					{
						SlidePosition++;
						if (SlidePosition == adverts.Count)
							SlidePosition = 0;
						OnlineAdvertsCarousel.Position = SlidePosition;

						return true;
					});

					online_activity_indicator.IsRunning = false;
				}
				catch (Exception ey)
				{
					Debug.WriteLine("" + ey);
				}

			}

			else
			{

				await DisplayAlert("Alert ", "No internet Connection Please ", "Ok");



			}



		}




	}
}
