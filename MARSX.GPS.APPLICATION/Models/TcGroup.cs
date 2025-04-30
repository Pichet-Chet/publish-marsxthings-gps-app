using System;
using System.Collections.Generic;

namespace MARSX.GPS.APPLICATION.Models;

public partial class TcGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Groupid { get; set; }

    public string? Attributes { get; set; }

    public virtual TcGroup? Group { get; set; }

    public virtual ICollection<TcGroup> InverseGroup { get; set; } = new List<TcGroup>();

    public virtual ICollection<TcDevice> TcDevices { get; set; } = new List<TcDevice>();
}
