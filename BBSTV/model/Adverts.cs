using System;




namespace BBSTV
{
	public class Adverts
	{

		public int ID { get; set; }
		public string clientID { get; set; }
		public DateTime startDate { get; set; }
		public DateTime expiryDate { get; set; }
		public string comments { get; set; }
		public string advert_photo { get; set; }
		public string client_name { get; set; }
		public string client_address { get; set; }
		public int longitude { get; set; }
		public int lattitude { get; set; }
		public string client_phone { get; set; }
		public string client_email { get; set; }
		public int client_biz_volume { get; set; }
		public int ID1 { get; set; }
		public const string BaseImageUrl = "http://bbs.eamobiledirectory.com/cooperp/Images/app_images/";
		public const string additional = "_photo.jpg";
		public string PhotoUrl2 { get { return BaseImageUrl + advert_photo + additional; } }


		//
		//public int ID { get; set; }
		public int categoryID { get; set; }
		public string company_name { get; set; }
		public string profile { get; set; }
		public double location_x { get; set; }
		public double location_y { get; set; }
		public string office_photo { get; set; }
		public string companylogo { get; set; }
		public string phone_contacts { get; set; }
		public string physical_address { get; set; }
		public string email { get; set; }
		public string website { get; set; }
		public string country { get; set; }
		public string branchcount { get; set; }
		public string featured { get; set; }
		public string enteredby { get; set; }
		public string approved { get; set; }
		public DateTime entryDate { get; set; }

		//public string PhotoUrl { get { return BaseImageUrl + office_photo; } }


	}
}
