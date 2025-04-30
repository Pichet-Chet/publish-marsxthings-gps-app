using System;
namespace MARSX.GPS.API.Models.Customs.MarsxTrack
{
    public class TcAttributesView
    {
        public TcAttributesView()
        {
        }

        public string? deviceImage { get; set; }

        public int? @event { get; set; }
        public int? sat { get; set; }
        public double? hdop { get; set; }
        public double? odometer { get; set; }
        public long? status { get; set; }
        public bool? ignition { get; set; }
        public bool? door { get; set; }
        public int? input { get; set; }
        public int? output { get; set; }
        public double? power { get; set; }
        public double? battery { get; set; }
        public double? adc2 { get; set; }
        public double? adc3 { get; set; }
        public double? distance { get; set; }
        public double? totalDistance { get; set; }
        public bool? motion { get; set; }
        public double? fuel { get; set; }
        public double? fuelLevel { get; set; }
        public double? fuelConsumption { get; set; }
        public double? throttle { get; set; }
        public double? coolantTemp { get; set; }
        public double? engineLoad { get; set; }
        public double? mapIntake { get; set; }
        public double? intakeTemp { get; set; }
        public double? airTemp { get; set; }
        public double? airflow { get; set; }
        public double? airPressure { get; set; }
        public long? hours { get; set; }
        public double? fuel_Index { get; set; }
        public int? batteryLevel { get; set; }
        public int? rpm { get; set; }
        public string? protocol { get; set; }
        public DateTime? serverTime { get; set; }
        public DateTime? deviceTime { get; set; }
        public DateTime? fixTime { get; set; }
        public double? speed { get; set; }
    }
}

