using System;
namespace MARSX.GPS.API.Models.Filters
{
	public class MasterGpsProviderFilter : GlobalFilter
	{
		public MasterGpsProviderFilter()
		{
		}

        public string? NameEn { get; set; }

        public string? NameTh { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }
    }
}

