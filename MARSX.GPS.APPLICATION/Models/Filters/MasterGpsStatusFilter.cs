using System;
namespace MARSX.GPS.APPLICATION.Models.Filters
{
	public class MasterGpsStatusFilter : GlobalFilter
	{
		public MasterGpsStatusFilter()
		{
		}

        public string? NameEn { get; set; }

        public string? NameTh { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }
    }
}

