using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class KhuyenMai
{
    public string MaKhuyenMai { get; set; } = null!;

    public string? TenKhuyenMai { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public int? UuDai { get; set; }

    public decimal? DieuKien { get; set; }

    public int? TinhTrang { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();
}
