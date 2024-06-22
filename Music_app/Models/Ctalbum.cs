using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class Ctalbum
{
    public string Idctalbum { get; set; } = null!;

    public string? Idalbum { get; set; }

    public string? IdbaiHat { get; set; }

    public virtual Album? IdalbumNavigation { get; set; }

    public virtual BaiHat? IdbaiHatNavigation { get; set; }
}
