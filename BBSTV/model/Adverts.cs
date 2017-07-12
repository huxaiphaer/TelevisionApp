using System;




namespace BBSTV
{
	public class Adverts
	{
		

			public int ID { get; set; }
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
		     public    const string BaseImageUrl = "http://eamobiledirectory.com/cooperp/Images/app_images/";
		    public string PhotoUrl { get { return BaseImageUrl + office_photo; } }
		    

	}
}
