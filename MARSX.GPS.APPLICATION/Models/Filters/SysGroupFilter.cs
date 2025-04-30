using System;
namespace MARSX.GPS.APPLICATION.Models.Filters
{
	public class SysGroupFilter : GlobalFilter
	{
		public SysGroupFilter()
		{
		}

        public string? NameEn { get; set; }

        public string? NameTh { get; set; }

        public string? Description { get; set; }

        public string? IsActive { get; set; }
    }
}

