using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcServer
{
    public int Id { get; set; }

    public bool Registration { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int Zoom { get; set; }

    public string? Map { get; set; }

    public string? Bingkey { get; set; }

    public string? Mapurl { get; set; }

    public bool Readonly { get; set; }

    public bool Twelvehourformat { get; set; }

    public string? Attributes { get; set; }

    public bool Forcesettings { get; set; }

    public string? Coordinateformat { get; set; }

    public bool? Devicereadonly { get; set; }

    public bool? Limitcommands { get; set; }

    public string? Poilayer { get; set; }

    public string? Announcement { get; set; }

    public bool? Disablereports { get; set; }

    public string? Overlayurl { get; set; }

    public bool? Fixedemail { get; set; }
}
