using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public int? TinhTrang { get; set; }

    public string MatKhau { get; set; } = null!;

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();
}
