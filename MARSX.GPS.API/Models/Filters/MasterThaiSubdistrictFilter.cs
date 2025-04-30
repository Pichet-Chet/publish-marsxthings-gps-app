using System;
using System.ComponentModel.DataAnnotations;

namespace MARSX.GPS.API.Models.Filters
{
	public class MasterThaiSubdistrictFilter : GlobalFilter
	{
		public MasterThaiSubdistrictFilter()
		{
		}

        public int? ZipCode { get; set; }

        public string? NameTh { get; set; }

        public string? NameEn { get; set; }

        [Required]
        public int DistrictsId { get; set; }
    }
}

