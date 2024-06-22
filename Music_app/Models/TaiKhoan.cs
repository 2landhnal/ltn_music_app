using System;
using System.Collections.Generic;

namespace Music_app.Models;

public partial class TaiKhoan
{
    public string TenTk { get; set; } = null!;

    public string? MatKhau { get; set; }

    public string? Iduser { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
