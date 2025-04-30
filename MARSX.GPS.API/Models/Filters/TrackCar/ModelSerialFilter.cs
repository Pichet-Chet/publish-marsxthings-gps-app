using System;
using System.ComponentModel.DataAnnotations;

namespace MARSX.GPS.API.Models.Filters.TrackCar
{
	public class ModelSerialFilter
	{
        [Required]
        public string Model { get; set; }

        [Required]
        public string Serial { get; set; }
    }
}

