using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public DateTime? NgayLap { get; set; }

    public string? NguoiLap { get; set; }

    public decimal? TongTien { get; set; }

    public decimal? TienKhachDua { get; set; }

    public decimal? TienThua { get; set; }

    public string? MaBan { get; set; }

    public string? TinhTrang { get; set; }

    public string? MaKh { get; set; }

    public string? MaKhuyenMai { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; } = new List<ChiTietHd>();

    public virtual Ban? MaBanNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual KhuyenMai? MaKhuyenMaiNavigation { get; set; }

    public virtual NhanVien? NguoiLapNavigation { get; set; }
}
