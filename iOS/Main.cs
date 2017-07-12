using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using Plugin.Media;
using UIKit;

namespace BBSTV.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static  void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.


			{

				try
				{


					UIApplication.Main(args, null, "AppDelegate");

					//CrossMedia.Current.Initialize();




				}


				catch (System.Threading.Tasks.TaskCanceledException ex)
				{

					Debug.WriteLine(""+ ex);
				}

				catch (Exception exx) { 
				Debug.WriteLine(""+ exx);
				}

			}
		}
	}
}
