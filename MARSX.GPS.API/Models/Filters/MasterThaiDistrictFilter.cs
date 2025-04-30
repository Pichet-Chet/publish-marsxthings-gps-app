using System;
using System.ComponentModel.DataAnnotations;

namespace MARSX.GPS.API.Models.Filters
{
	public class MasterThaiDistrictFilter : GlobalFilter
	{
		public MasterThaiDistrictFilter()
		{
		}

        public string? NameTh { get; set; }

        public string? NameEn { get; set; }

		[Required]
        public int ProvinceId { get; set; }
    }
}

