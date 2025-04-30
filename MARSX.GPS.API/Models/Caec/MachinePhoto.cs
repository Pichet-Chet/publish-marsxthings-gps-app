using System;
namespace MARSX.GPS.API.Models.Caec
{
	public class MachinePhoto
	{
		public MachinePhoto()
		{
		}

        public long? id { get; set; }
        public int? machineId { get; set; }
        public string? photoLabel { get; set; }
        public string? photoDescription { get; set; }
        public string? photoPath { get; set; }
        public DateTime? createDate { get; set; }
        public string? createUser { get; set; }
        public bool? isCoverPage { get; set; }
        public int? photoSeq { get; set; }
    }
}

