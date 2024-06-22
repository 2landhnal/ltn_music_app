using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class Dsphat
{
    public string Iddsphat { get; set; } = null!;

    public string? TenDsphat { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string? Iduser { get; set; }

    public virtual ICollection<Ctdsphat> Ctdsphats { get; set; } = new List<Ctdsphat>();

    public virtual User? IduserNavigation { get; set; }
}
