
using System;
namespace MARSX.GPS.API.Models.Caec
{
	public class Vehicles
	{
		public Vehicles()
		{
		}

        public int? vehicle_id { get; set; }
        public int? terminal_id { get; set; }
        public string? registration { get; set; }
        public string? default_timezone { get; set; }
        public int? monthly_mileage_limit { get; set; }
        public string? tolling_tag_id { get; set; }
        public string? vehicle_name { get; set; }
        public string? client_vehicle_description { get; set; }
        public string? client_vehicle_description2 { get; set; }
        public string? client_vehicle_description3 { get; set; }
        public string? licence_code { get; set; }
        public DateTime? licence_issued_date { get; set; }
        public DateTime? licence_expiry_date { get; set; }
        public int? max_speed { get; set; }
        public string? manufacturer { get; set; }
        public string? default_driver { get; set; }
        public string? home_geofence { get; set; }
        public string? model { get; set; }
        public int? model_year { get; set; }
        public string? colour { get; set; }
        public string? chassis_number { get; set; }
    }
}

