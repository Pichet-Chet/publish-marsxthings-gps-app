using System;
namespace MARSX.GPS.API.Models.Caec
{
	public class CaecResponse
	{
        public bool? status { get; set; }
        public int? statuS_CODE { get; set; }
        public int? httP_CODE { get; set; }
        public string? code { get; set; }
        public string? message { get; set; }
        public string? erroR_MESSAGE { get; set; }
        public string? erroR_STACK { get; set; }
        public string? inneR_EXCEPTION { get; set; }
        public string? currenT_METHOD { get; set; }
        public object? outpuT_DATA { get; set; }
        public string? responsE_TIME { get; set; }
        public int? pagE_NUMBER { get; set; }
        public int? pagE_SIZE { get; set; }
        public int? effecT_ROW { get; set; }
    }
}

