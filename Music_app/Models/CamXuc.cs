using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class CamXuc
{
    public string IdcamXuc { get; set; } = null!;

    public string? IdbaiHat { get; set; }

    public string? CamXuc1 { get; set; }

    public string? Iduser { get; set; }

    public DateTime? Thoigian { get; set; }

    public virtual BaiHat? IdbaiHatNavigation { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
