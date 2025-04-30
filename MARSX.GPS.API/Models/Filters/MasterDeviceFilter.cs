using System;
namespace MARSX.GPS.API.Models.Filters
{
	public class MasterDeviceFilter : GlobalFilter
	{
		public MasterDeviceFilter()
		{

		}

        public int? Id { get; set; }

        public int? MasterGpsProviderId { get; set; }

        public string? RefTrackingId { get; set; }

        public int? MasterDeviceStatusId { get; set; }

        public bool? IsActive { get; set; }

        public string? Name { get; set; }

        public string? Model { get; set; }

        public string? Phone { get; set; }

        public string? Contact { get; set; }

        public int? MasterDeviceGroupId { get; set; }

        public int? MasterDeviceCategoryId { get; set; }

        public string? TagAction { get; set; }

        public string? Username { get; set; }

    }
}

