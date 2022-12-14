using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ChiTietPn
{
    public string MaDonHang { get; set; } = null!;

    public string MaNl { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual ChiTietDh Ma { get; set; } = null!;

    public virtual PhieuNhap MaDonHangNavigation { get; set; } = null!;
}
