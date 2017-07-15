using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;
namespace BBSTV
{
	public class MyLocal
	{
		private static ISettings AppSettings
		{
			get { return CrossSettings.Current; }
		}

		private const string UserNameKey = "username_key";
		private static readonly string UserNameDefault = string.Empty;

		//Holding the User Name With this method.
		public static string User_(string usn)
		{

			return usn;
		}

		public static bool OnLoggedIn(string key) =>
		AppSettings.GetValueOrDefault("login" + key, true);

		public static string UserName
		{
			get { return AppSettings.GetValueOrDefault(nameof(User_), UserNameDefault); }
			set { AppSettings.AddOrUpdateValue(nameof(UserNameKey), value); }
		}


	}
}
