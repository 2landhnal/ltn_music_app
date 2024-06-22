using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class CtdsdgoiY
{
    public string IdctdsgoiY { get; set; } = null!;

    public string? IddsgoiY { get; set; }

    public string? IdbaiHat { get; set; }

    public virtual BaiHat? IdbaiHatNavigation { get; set; }

    public virtual DsgoiY? IddsgoiYNavigation { get; set; }
}
