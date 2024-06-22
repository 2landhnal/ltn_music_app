using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class TheLoai
{
    public string IdtheLoai { get; set; } = null!;

    public string? TenTl { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<BaiHat> BaiHats { get; set; } = new List<BaiHat>();
}
