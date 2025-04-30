using System;
namespace MARSX.GPS.APPLICATION.Models.Filters.TrackCar
{
	public class PositionFilter : GlobalFilter
	{
        public PositionFilter()
        {
        }
        public int? id { get; set; }
        public int? deviceId { get; set; }
        public DateTime? from { get; set; }
        public DateTime? to { get; set; }
        public bool? isLast { get; set; }
    }
}

