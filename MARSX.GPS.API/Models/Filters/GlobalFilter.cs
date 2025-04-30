using System;
using MARSX.GPS.API.Models.PaginationModel;

namespace MARSX.GPS.API.Models.Filters
{
    public class GlobalFilter : Pagination
    {
		public string? textSearch { get; set; }

        public bool? isAll { get; set; }

	}
}

