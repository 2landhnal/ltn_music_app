using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class BaiHat
{
    public string IdbaiHat { get; set; } = null!;

    public string? TenBaiHat { get; set; }

    public TimeOnly? ThoiGian { get; set; }

    public string? IdtheLoai { get; set; }

    public string? LinkNhac { get; set; }

    public string? LinkAnh { get; set; }

    public string? IdtacGia { get; set; }

    public long? LuotNghe { get; set; }

    public virtual ICollection<CamXuc> CamXucs { get; set; } = new List<CamXuc>();

    public virtual ICollection<Ctalbum> Ctalbums { get; set; } = new List<Ctalbum>();

    public virtual ICollection<CtdsdgoiY> CtdsdgoiYs { get; set; } = new List<CtdsdgoiY>();

    public virtual ICollection<Ctdsphat> Ctdsphats { get; set; } = new List<Ctdsphat>();

    public virtual TacGium? IdtacGiaNavigation { get; set; }

    public virtual TheLoai? IdtheLoaiNavigation { get; set; }

    public virtual ICollection<LichSu> LichSus { get; set; } = new List<LichSu>();
}
