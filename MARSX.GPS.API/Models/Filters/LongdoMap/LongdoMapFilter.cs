using System;
namespace MARSX.GPS.API.Models.Filters.LongdoMap
{
	public class LongdoMapFilter
	{
		public LongdoMapFilter()
		{
		}

        public string? key { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
    }
}

