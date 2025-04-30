using System;
namespace MARSX.GPS.API.Models.Filters.TrackCar
{
	public class DevicesFilter : GlobalFilter
	{
		public DevicesFilter()
		{
		}

		public string? name { get; set; }

		public bool? all { get; set; }

		public int? userId { get; set; }

		public int? id { get; set; }

		public int? uniqueId { get; set; }
	}
}

