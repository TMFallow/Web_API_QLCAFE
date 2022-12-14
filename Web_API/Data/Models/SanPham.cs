using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? MaLoai { get; set; }

    public string? TenSp { get; set; }

    public decimal? DonGia { get; set; }

    public string? HinhAnh { get; set; }

    public int? TinhTrang { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; } = new List<ChiTietHd>();

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; } = new List<ChiTietSanPham>();

    public virtual LoaiSp? MaLoaiNavigation { get; set; }
}
