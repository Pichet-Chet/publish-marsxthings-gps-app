using System;
using MARSX.GPS.APPLICATION.Models.Longdo;

namespace MARSX.GPS.APPLICATION.Models.Customs.MarsxTrack
{
    public class TcDevicesView
    {
		public TcDevicesView()
		{
		}

        public int? id { get; set; }
        public TcAttributesView? attributes { get; set; }
        public int? groupId { get; set; }
        public int? calendarId { get; set; }
        public string? name { get; set; }
        public string? uniqueId { get; set; }
        public string? status { get; set; }
        public DateTime? lastUpdate { get; set; }
        public int? positionId { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string? phone { get; set; }
        public string? model { get; set; }
        public string? contact { get; set; }
        public string? category { get; set; }
        public bool? disabled { get; set; }
        public object? expirationTime { get; set; }
    }
}

