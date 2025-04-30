using System;
namespace MARSX.GPS.API.Models.Caec
{
	public class CustomerMaster
	{
		public CustomerMaster()
		{
		}

        public string? customerId { get; set; }
        public string? customerType { get; set; }
        public string? customerGroup { get; set; }
        public string? prefixName { get; set; }
        public string? companyName { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public object? gender { get; set; }
        public string? address { get; set; }
        public int? tambonId { get; set; }
        public int? distinctId { get; set; }
        public int? provinceId { get; set; }
        public string? telephone { get; set; }
        public string? emailAddess { get; set; }
        public string? active { get; set; }
        public DateTime? createDate { get; set; }
        public string? createUser { get; set; }
        public DateTime? updateDate { get; set; }
        public string? updateUser { get; set; }
        public string? personalId { get; set; }
        public string? taxId { get; set; }
        public string? lineId { get; set; }
        public string? contactName { get; set; }
        public string? contactTel { get; set; }
        public string? contactEmailAddress { get; set; }
        public string? tambonTh { get; set; }
        public string? tambonEng { get; set; }
        public string? tambonThShort { get; set; }
        public string? tamboonEnShort { get; set; }
        public string? districtTh { get; set; }
        public string? districtEng { get; set; }
        public string? districtThSort { get; set; }
        public string? districtEngShort { get; set; }
        public string? postcode { get; set; }
        public string? provinceTh { get; set; }
        public string? provinceEng { get; set; }
        public string? region { get; set; }
        public string? metropolitans { get; set; }
        public string? displayName { get; set; }
    }
}

