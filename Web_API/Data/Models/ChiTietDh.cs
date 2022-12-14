using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class ChiTietDh
{
    public string MaDonHang { get; set; } = null!;

    public string MaNl { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual ChiTietPn? ChiTietPn { get; set; }

    public virtual DonDatHang MaDonHangNavigation { get; set; } = null!;

    public virtual NguyenLieu MaNlNavigation { get; set; } = null!;
}
