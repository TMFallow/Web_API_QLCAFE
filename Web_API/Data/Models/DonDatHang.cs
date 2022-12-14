using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class DonDatHang
{
    public string MaDonHang { get; set; } = null!;

    public string? MaNcc { get; set; }

    public DateTime? NgayDatHang { get; set; }

    public decimal? TongTien { get; set; }

    public string? TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietDh> ChiTietDhs { get; } = new List<ChiTietDh>();

    public virtual NhaCungCap? MaNccNavigation { get; set; }

    public virtual PhieuNhap? PhieuNhap { get; set; }
}
