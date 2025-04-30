using System;
using System.Collections.Generic;

namespace MARSX.GPS.API.Models;

public partial class TcUserUser
{
    public int Userid { get; set; }

    public int Manageduserid { get; set; }

    public virtual TcUser Manageduser { get; set; } = null!;

    public virtual TcUser User { get; set; } = null!;
}
