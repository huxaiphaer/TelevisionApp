using Plugin.MediaManager.Forms;
using Xamarin.Forms;

namespace BBSTV
{





	public partial class App : Application
	{
		public App()
		{

			var workaround = typeof(VideoView);
		     InitializeComponent();

			MainPage = new NavigationPage(new MainActivity())

			{
				BarBackgroundColor = Color.FromHex("#4D7EE1"),
				BarTextColor = Color.White


			};



		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
