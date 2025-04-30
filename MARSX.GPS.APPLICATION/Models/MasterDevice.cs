using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class MasterDevice
{
    public int Id { get; set; }

    public int? MasterGpsProviderId { get; set; }

    public string? RefTrackingId { get; set; }

    public int? MasterDeviceStatusId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public string? Name { get; set; }

    public string? Model { get; set; }

    public string? Phone { get; set; }

    public string? Contact { get; set; }

    public int? MasterDeviceGroupId { get; set; }

    public int? MasterDeviceCategoryId { get; set; }

    public string? Description { get; set; }

    public string? ModelYear { get; set; }

    public string? Manufacturer { get; set; }

    public string? SerialNo { get; set; }

    public string? Chassis { get; set; }

    public string? CarNo { get; set; }

    public string? CompanyOwnerName { get; set; }
}
