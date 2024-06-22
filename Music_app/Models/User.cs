using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class User
{
    public string Iduser { get; set; } = null!;

    public string? TenUser { get; set; }

    public string? GioiTinh { get; set; }

    public string? QuocTich { get; set; }

    public string? Sdt { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public virtual ICollection<CamXuc> CamXucs { get; set; } = new List<CamXuc>();

    public virtual ICollection<DsgoiY> DsgoiYs { get; set; } = new List<DsgoiY>();

    public virtual ICollection<Dsphat> Dsphats { get; set; } = new List<Dsphat>();

    public virtual ICollection<LichSu> LichSus { get; set; } = new List<LichSu>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
