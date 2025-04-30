using System;
namespace MARSX.GPS.API.Models.Caec
{
	public class VehiclesLatestStatus
	{
		public VehiclesLatestStatus()
		{
		}

        public int? vehicle_id { get; set; }
        public string? registration { get; set; }
        public string? chassis_number { get; set; }
        public DateTime? event_ts { get; set; }
        public int? bearing { get; set; }
        public int? speed { get; set; }
        public bool? ignition { get; set; }
        public int? odometer { get; set; }
        public int? clock { get; set; }
        public int? altitude { get; set; }
        public int? rpm { get; set; }
        public int? road_speed { get; set; }
        public double? vext { get; set; }
        public int? temp1 { get; set; }
        public int? temp2 { get; set; }
        public int? temp3 { get; set; }
        public int? temp4 { get; set; }
        public string? last_identification_tag_id { get; set; }
        public string? io_panic { get; set; }
        public string? io_disarm { get; set; }
        public DateTime? fuel_updated { get; set; }
        public int? fuel_level { get; set; }
        public int? fuel_precentage_left { get; set; }
        public string? fuel_total_consumed { get; set; }
        public string? driver_id { get; set; }
        public int? electric_battery_percentage_left { get; set; }
        public DateTime? electric_battery_ts { get; set; }
        public DateTime? location_updated { get; set; }
        public double? location_longitude { get; set; }
        public double? location_latitude { get; set; }
        public int? location_gps_fix_type { get; set; }
        public string? location_position_description { get; set; }
        public string? driver_first_name { get; set; }
        public string? driver_last_name { get; set; }
        public string? driver_id_number { get; set; }
        public string? driver_license_number { get; set; }
        public string? driver_tag_id { get; set; }
        public string? driver_phone_number { get; set; }
        public DateTime? update_date { get; set; }
    }
}

