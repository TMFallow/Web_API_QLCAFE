using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class PhieuNhap
{
    public string MaDonHang { get; set; } = null!;

    public DateTime? NgayGiaoHang { get; set; }

    public decimal? TongTien { get; set; }

    public string? GhiChu { get; set; }

    public string? MaNv { get; set; }

    public virtual ICollection<ChiTietPn> ChiTietPns { get; } = new List<ChiTietPn>();

    public virtual DonDatHang MaDonHangNavigation { get; set; } = null!;

    public virtual NhanVien? MaNvNavigation { get; set; }
}
