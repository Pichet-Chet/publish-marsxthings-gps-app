using System;
namespace MARSX.GPS.API.Models.Filters
{
	public class SysDeviceFavoriteFilter : GlobalFilter
    {
		public SysDeviceFavoriteFilter()
		{

		}

        public int? Id { get; set; }

        public int? DeviceId { get; set; }

        public int? UserId { get; set; }

        public string? UserName { get; set; }

    }
}

