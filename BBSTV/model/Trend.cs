using System;
namespace BBSTV
{
	public class Trend
	{
		public string show_pic { get; set; }
		public string show_name { get; set; }
		public string show_time { get; set; }
		public const string additional = "_photo.jpg";
		// Images retrieval
		private const string BaseImageUrl = "http://bbs.eamobiledirectory.com/cooperp/images/app_images/";
		public string PhotoUrl { get { return BaseImageUrl + show_pic + additional; } }

	}
}
