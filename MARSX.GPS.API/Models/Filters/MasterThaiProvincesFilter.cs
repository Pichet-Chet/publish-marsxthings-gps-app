using System;
namespace MARSX.GPS.API.Models.Filters
{
	public class MasterThaiProvincesFilter : GlobalFilter
	{
		public MasterThaiProvincesFilter()
		{
			NameTh = string.Empty;
			NameEn = string.Empty;
		}

        public string? NameTh { get; set; }

        public string? NameEn { get; set; }
    }
}

