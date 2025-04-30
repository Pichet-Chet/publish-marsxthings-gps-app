using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class SysLog
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? ClientLatitude { get; set; }

    public string? ClientLongitude { get; set; }

    public string? ClientAgent { get; set; }

    public string? ClientBrowser { get; set; }

    public string? ClientPlatform { get; set; }

    public string? ClientLanguage { get; set; }

    public string? ClientDevice { get; set; }

    public string? ClientDatetime { get; set; }

    public string? ServerDatetime { get; set; }

    public string? ClientIp { get; set; }

    public string? ClientAddress { get; set; }

    public string? IspName { get; set; }

    public string? IspCountry { get; set; }
}
