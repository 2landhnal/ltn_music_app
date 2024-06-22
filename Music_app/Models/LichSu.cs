using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class LichSu
{
    public string Idls { get; set; } = null!;

    public string? Iduser { get; set; }

    public string? IdbaiHat { get; set; }

    public DateTime? Thoigian { get; set; }

    public virtual BaiHat? IdbaiHatNavigation { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
