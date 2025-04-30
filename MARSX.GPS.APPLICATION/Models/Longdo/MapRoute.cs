using System;
namespace MARSX.GPS.APPLICATION.Models.Longdo
{
    public class MapRoute
    {
        public MapRoute()
        {
        }

        public double? startLat { get; set; }
        public double? startLon { get; set; }

        public double? endLat { get; set; }
        public double? endLon { get; set; }

        public string? name { get; set; }
        public string? address { get; set; }
    }
}

