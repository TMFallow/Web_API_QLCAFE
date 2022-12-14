using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ChiTietSanPham
{
    public string MaSp { get; set; } = null!;

    public string MaNl { get; set; } = null!;

    public int? SoLuong { get; set; }

    public virtual NguyenLieu MaNlNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
