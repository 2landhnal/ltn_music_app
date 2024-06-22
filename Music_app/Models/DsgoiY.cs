using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class DsgoiY
{
    public string IddsgoiY { get; set; } = null!;

    public string? TenDsgoiY { get; set; }

    public string? Iduser { get; set; }

    public virtual ICollection<CtdsdgoiY> CtdsdgoiYs { get; set; } = new List<CtdsdgoiY>();

    public virtual User? IduserNavigation { get; set; }
}
