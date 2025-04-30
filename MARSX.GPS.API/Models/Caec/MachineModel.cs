using System;
namespace MARSX.GPS.API.Models.Caec
{
	public class MachineModel
	{
		public MachineModel()
		{
		}

        public string? machineGroup { get; set; }
        public string? machineModel1 { get; set; }
        public string? description { get; set; }
        public string? active { get; set; }
        public DateTime? createDate { get; set; }
        public string? createUser { get; set; }
        public DateTime? updateDate { get; set; }
        public string? updateUser { get; set; }
        public string? machineModelGobal { get; set; }
        public string? machineSubGroup { get; set; }
    }
}

