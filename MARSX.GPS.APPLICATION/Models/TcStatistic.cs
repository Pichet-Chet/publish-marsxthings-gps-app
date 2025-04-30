using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcStatistic
{
    public int Id { get; set; }

    public DateTime Capturetime { get; set; }

    public int Activeusers { get; set; }

    public int Activedevices { get; set; }

    public int Requests { get; set; }

    public int Messagesreceived { get; set; }

    public int Messagesstored { get; set; }

    public string Attributes { get; set; } = null!;

    public int Mailsent { get; set; }

    public int Smssent { get; set; }

    public int Geocoderrequests { get; set; }

    public int Geolocationrequests { get; set; }

    public string? Protocols { get; set; }
}
