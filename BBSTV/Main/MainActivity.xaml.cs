using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BBSTV
{


	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class MainActivity : ContentPage
	{

		public ObservableCollection<Adverts> Zoos { get; set; }

		public int Count = 0;
		public short Counter = 0;
		public int SlidePosition = 0;
		string heightList;
		int heightRowsList = 90;

		private const string Url = "http://bbs.eamobiledirectory.com/Mobile/mobileApi.aspx?Action=TrendingShows";
		private const string BaseImageUrl = "http://eamobiledirectory.com/cooperp/Images/app_images/";
		private const string Url_Trend = "http://bbs.eamobiledirectory.com/Mobile/mobileApi.aspx?Action=TrendingShows";
		private const string Url_News = "http://bbs.eamobiledirectory.com/Mobile/mobileApi.aspx?Action=NewsHeadlines";
		private HttpClient _client = new HttpClient();
		public ObservableCollection<Adverts> adverts;
		//	public ObservableCollection<Trend> trends;
		public MainActivity()
		{
			InitializeComponent();



			//TrendingShows();




			//LoadData();
			OnNewsList();

			OnTrendingList();







			trendingShowslist.ItemTapped += async (sender, args) =>
			{

				await Navigation.PushAsync(new TrendingShowsDetails());
				trendingShowslist.SelectedItem = null;
			};

			newslist.ItemTapped += async (sender, args) =>
			{

				await Navigation.PushAsync(new NewsDetails());
				newslist.SelectedItem = null;
			};



		}


		async void onImageOnlineTapped(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new OnlineStreaming());

		}



		async void onImageCitizenReporterTapped(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new CitizenReporter());

		}






		protected override async void OnAppearing()
		{
			if (CrossConnectivity.Current.IsConnected)
			{

				try
				{
					//Activity indicator visibility on
					//App_activity_indicator.IsVisible = true;

					var content = await _client.GetStringAsync(Url);
					var adv = JsonConvert.DeserializeObject<List<Adverts>>(content);

					adverts = new ObservableCollection<Adverts>(adv);

					AdvertsCarousel.ItemsSource = adverts;
					// activity indicator visisbility is off .
					//App_activity_indicator.IsVisible = false;

					// attaching auto sliding on to carouselView 
					Device.StartTimer(TimeSpan.FromSeconds(18), () =>
					{
						SlidePosition++;
						if (SlidePosition == adverts.Count)
							SlidePosition = 0;
						AdvertsCarousel.Position = SlidePosition;
						return true;
					});
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





		// Dealing with News Headlines 
		protected async void OnNewsList()
		{
			if (CrossConnectivity.Current.IsConnected)
			{

				try
				{
					//Activity indicator visibility on
					news_activity_indicator.IsRunning = true;

					var content = await _client.GetStringAsync(Url_News);
					var n = JsonConvert.DeserializeObject<List<News>>(content);

					ObservableCollection<News> trends = new ObservableCollection<News>(n);

					newslist.ItemsSource = trends;


					int i = trends.Count;
					if (i > 0)
					{
						news_activity_indicator.IsRunning = false;
					}
					i = (trends.Count * heightRowsList);
					newslist.HeightRequest = i;



				}
				catch (Exception ey)
				{
					Debug.WriteLine("" + ey);
				}

			}

			else
			{
				newslist.IsVisible = false;
				await DisplayAlert("Alert ", "No internet Connection Please ", "Ok");



			}

		}







		// Dealing with Trending shows 

		protected async void OnTrendingList()
		{
			if (CrossConnectivity.Current.IsConnected)
			{

				try
				{
					//Activity indicator visibility on
					App_activity_indicator.IsRunning = true;

					var content = await _client.GetStringAsync(Url_Trend);
					var tr = JsonConvert.DeserializeObject<List<Trend>>(content);

					ObservableCollection<Trend> trends = new ObservableCollection<Trend>(tr);

					trendingShowslist.ItemsSource = trends;


					int i = trends.Count;
					if (i > 0)
					{
						App_activity_indicator.IsRunning = false;
					}
					i = (trends.Count * heightRowsList);
					trendingShowslist.HeightRequest = i;



				}
				catch (Exception ey)
				{
					Debug.WriteLine("" + ey);
				}

			}

			else
			{

				trendingShowslist.IsVisible = false;
				await DisplayAlert("Alert ", "No internet Connection Please ", "Ok");



			}



		}


		public async void OnLogin(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new LoginSales());

		}







			/*


	// Another way of retrieving data into the listView 
			public async void LoadData()
			{
				var content = "";
				HttpClient client = new HttpClient();


				client.BaseAddress = new Uri(Url_Trend);
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = await client.GetAsync(Url_Trend);
				content = await response.Content.ReadAsStringAsync();
				var Items = JsonConvert.DeserializeObject<List<Trend>>(content);
				trendingShowslist.ItemsSource = Items;

				int i = Items.Count;
				i = (Items.Count * heightRowsList);
				trendingShowslist.HeightRequest = i;
			}
	*/
		}
	}
