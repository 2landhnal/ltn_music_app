using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class Ctdsphat
{
    public string Idctdsphat { get; set; } = null!;

    public string? Iddsphat { get; set; }

    public string? IdbaiHat { get; set; }

    public virtual BaiHat? IdbaiHatNavigation { get; set; }

    public virtual Dsphat? IddsphatNavigation { get; set; }
}
