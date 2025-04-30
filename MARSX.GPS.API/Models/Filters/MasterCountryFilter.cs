using System;
namespace MARSX.GPS.API.Models.Filters
{
	public class MasterThaiDistrictsFilter : GlobalFilter
	{
		public MasterThaiDistrictsFilter()
		{
		}

        public string? Code { get; set; }

        public string? CurrencyCode { get; set; }

        public string? NameEn { get; set; }

        public string? NameTh { get; set; }

        

        
    }
}

