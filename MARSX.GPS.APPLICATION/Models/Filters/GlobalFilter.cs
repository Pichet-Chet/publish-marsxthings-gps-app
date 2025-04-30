using System;
using MARSX.GPS.APPLICATION.Models.Pagination;

namespace MARSX.GPS.APPLICATION.Models.Filters
{
    public class GlobalFilter : PaginationModel
    {
        public string? textSearch { get; set; }

        public bool? isAll { get; set; }

    }
}

