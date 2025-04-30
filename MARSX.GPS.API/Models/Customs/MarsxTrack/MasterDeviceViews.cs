using System;
namespace MARSX.GPS.API.Models.Customs.MarsxTrack
{
    public class MasterDeviceViews
    {
        public MasterDeviceViews()
        {
            LongdoMap = new longdoMap();
        }

        public int? Id { get; set; }

        public MasterGpsProvider? MasterGpsProvider { get; set; }

        public string? RefTrackingId { get; set; }

        public MasterDeviceStatus? MasterDeviceStatus { get; set; }

        public bool? IsActive { get; set; }

        public string? Name { get; set; }

        public string? Model { get; set; }

        public string? ModelYear { get; set; }

        public string? Manufacturer { get; set; }

        public string? Phone { get; set; }

        public string? Contact { get; set; }

        public MasterDeviceGroup? MasterDeviceGroup { get; set; }

        public MasterDeviceCategory? MasterDeviceCategory { get; set; }

        public string? Description { get; set; }

        public double? Lat { get; set; }

        public double? Lon { get; set; }

        public string? Address { get; set; }

        public string? GpsStatus { get; set; }

        public TcAttributesView? TcAttributesView { get; set; }

        public TcDevicesView? TcDevicesView { get; set; }

        public TagDevice? TagDevice { get; set; }

        public longdoMap? LongdoMap { get; set; }

        public string? PhotoPath { get; set; }

        public string? SerialNo { get; set; }

        public string? Chassis { get; set; }

        public string? CarNo { get; set; }

        public string? CompanyOwnerName { get; set; }

        public bool isFavorite { get; set; }
    }


    public class TagDevice
    {
        public int? tagCount { get; set; }

        public int? tagOnline { get; set; }

        public int? tagStart { get; set; }
    }

    public class longdoMap
    {
        public string? key { get; set; }
    }
}

