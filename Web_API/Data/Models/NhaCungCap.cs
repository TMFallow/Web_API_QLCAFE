using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? HinhAnh { get; set; }

    public int? TinhTrang { get; set; }

    public virtual ICollection<DonDatHang> DonDatHangs { get; } = new List<DonDatHang>();

    public virtual ICollection<NguyenLieu> NguyenLieus { get; } = new List<NguyenLieu>();
}
