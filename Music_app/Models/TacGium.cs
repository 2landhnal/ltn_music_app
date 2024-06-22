using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class TacGium
{
    public string IdtacGia { get; set; } = null!;

    public string? TenTg { get; set; }

    public DateOnly? Ns { get; set; }

    public string? QueQuan { get; set; }

    public string? TieuSu { get; set; }

    public string? GioiTinh { get; set; }

    public string? LinkAnh { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<BaiHat> BaiHats { get; set; } = new List<BaiHat>();
}
