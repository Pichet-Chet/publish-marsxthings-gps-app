using System;
namespace MARSX.GPS.APPLICATION.Models.Filters
{
	public class SysDeviceFavoriteFilter
	{
		public SysDeviceFavoriteFilter()
		{
		}

        public int? Id { get; set; }

        public int? DeviceId { get; set; }

        public int? UserId { get; set; }

        public string? Username { get; set; }
    }
}

