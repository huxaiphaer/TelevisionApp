using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Plugin.Media;
using Xamarin.Forms;
using System.IO;
using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;


namespace BBSTV
{
	public partial class CitizenReporter : ContentPage
	{

		private MediaFile _mediaFile;
		public CitizenReporter()
		{
			InitializeComponent();

			InitializeComponent();

			/*
			citizenReport_picker.SelectedIndexChanged += (sender, args) =>
			{
				if (citizenReport_picker.SelectedIndex == 0)
				{
					DisplayAlert("Media Formatt", "You have selected  videos.", "OK");

				}
				else
				{
					DisplayAlert("Media Formatt", "You selected Images ", "OK");
					return;
				}
			};

*/



		}








		private async void onTakeMedia(object sender, EventArgs e)
		{
			if (citizenReport_picker.SelectedIndex == 0)
			{




				// take video 

				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
				{
					DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
					return;
				}

				_mediaFile = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
				{
					Name = "video.mp4",
					Directory = "DefaultVideos",
				});

				if (_mediaFile == null)
					return;


				DisplayAlert("Video Recorded", "Location: ", "OK");

				_mediaFile.Dispose();


			}



			else if (citizenReport_picker.SelectedIndex == 1)
			{

				// take photo ..
				await CrossMedia.Current.Initialize();

				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					await DisplayAlert("No Camera", ":( No camera available.", "OK");
					return;
				}

				_mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
				{
					Directory = "Sample",
					Name = "myImage.jpg"
				});

				if (_mediaFile == null)
					return;

				//	attachment_label.Text = _mediaFile.Path;

				citizenImage.Source = ImageSource.FromStream(() =>
				{
					return _mediaFile.GetStream();
				});
			}

			else
			{

                DisplayAlert("Alert ", "Please  first select any media type", "OK");
			}
		}






		//new 

		private async void onChooseMedia(object sender, EventArgs e)
		{


			if (citizenReport_picker.SelectedIndex == 0)
			{


				if (!CrossMedia.Current.IsPickVideoSupported)
				{
					DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
					return;
				}
				_mediaFile = await CrossMedia.Current.PickVideoAsync();

				if (_mediaFile == null)
					return;


				DisplayAlert("Video Selected", "Location: ", "OK");
				_mediaFile.Dispose();

			}

			else if (citizenReport_picker.SelectedIndex == 1)
			{

				await CrossMedia.Current.Initialize();

				if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					await DisplayAlert("No PickPhoto", ":( No PickPhoto available.", "OK");
					return;
				}

				_mediaFile = await CrossMedia.Current.PickPhotoAsync();

				if (_mediaFile == null)
					return;

				//	attachment_label.Text = _mediaFile.Path;

				citizenImage.Source = ImageSource.FromStream(() =>
				{
					return _mediaFile.GetStream();
				});

			}

			else
			{

				DisplayAlert("Alert ", "Please first  select any media type", "OK");
			}
		}








		async void onTakeVideo(object sender, System.EventArgs e)

		{

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
			{
				DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
				return;
			}

			_mediaFile = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
			{
				Name = "video.mp4",
				Directory = "DefaultVideos",
			});

			if (_mediaFile == null)
				return;


			DisplayAlert("Video Recorded", "Location: ", "OK");

			_mediaFile.Dispose();

		}





		// Uploading an Image to the server ....

		private async void UploadFile_Clicked(object sender, EventArgs e)
		{

			//if () { }


			try
			{
				activity_i_citizenReport.IsRunning = true;

				using (var client = new HttpClient())
				{



					//var response = await client.GetAsync($"http://bbs.eamobiledirectory.com/Mobile/mobileApi.aspx?Action=NewsUpload&name={names_entry.Text}" +
					//           "&phone={phoneNumber_entry.Text}&" +
					// "title={title_entry.Text}&comments={details_entry.Text}");

					// TODO do something with response

					//await	DisplayAlert("Notification ", "" + response, "OK");

					var content = new MultipartFormDataContent();

					content.Add(new StreamContent(_mediaFile.GetStream()),
						"\"file\"",
						$"\"{_mediaFile.Path}\"");

					//	var httpClient = new HttpClient();

					//	var uploadServiceBaseAddress = "http://bbs.eamobiledirectory.com/Mobile/mobileApi.aspx?Action=NewsUpload" +
					//		"&name={names_entry.Text}&phone={phoneNumber_entry.Text}&title={title_entry.Text}&comments={details_entry.Text}";
					var uploadServiceBaseAddress = "http://bbs.eamobiledirectory.com/Mobile/mobileApi.aspx?Action=NewsUpload";
					//"http://localhost:12214/api/Files/Upload";

					var httpResponseMessage = await client.PostAsync(uploadServiceBaseAddress, content);

					string IsUploaded = await httpResponseMessage.Content.ReadAsStringAsync();

					activity_i_citizenReport.IsRunning = false;
					//
					if (IsUploaded != null)
					{
						await DisplayAlert("Notification ", "" + httpResponseMessage.RequestMessage + "  " + IsUploaded, "OK");

					}




					//activity_i_citizenReport.IsVisible = false;


				}




				// clearing the entries 

				title_entry.Text = string.Empty;
				details_entry.Text = string.Empty;
			}
			catch (Exception exx)

			{

				Debug.WriteLine("This is my Exception : " + exx);
			}


		}



	}
}

