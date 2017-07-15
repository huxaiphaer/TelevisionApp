using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BBSTV
{
	public partial class SalesTab : ContentPage
	{
		public SalesTab()
		{
			InitializeComponent();


		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{

             var  local = new LocalDB();
			string name = local.GetUsernames();
              DisplayAlert("Message  ", " Name : " + name , "OK");
		}
	}
}
