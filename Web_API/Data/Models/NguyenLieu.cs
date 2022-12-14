using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class NguyenLieu
{
    public string MaNl { get; set; } = null!;

    public string? MaNcc { get; set; }

    public string? TenNl { get; set; }

    public decimal? DonGia { get; set; }

    public double? SoLuong { get; set; }

    public string? Dvt { get; set; }

    public string? HinhAnh { get; set; }

    public int? TinhTrang { get; set; }

    public virtual ICollection<ChiTietDh> ChiTietDhs { get; } = new List<ChiTietDh>();

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; } = new List<ChiTietSanPham>();

    public virtual NhaCungCap? MaNccNavigation { get; set; }
}
