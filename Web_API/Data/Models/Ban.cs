using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Ban
{
    public string MaBan { get; set; } = null!;

    public string? TenBan { get; set; }

    public int? TinhTrang { get; set; }

    public string? MaKhu { get; set; }

    public DateTime? NgayDatBan { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual Khu? MaKhuNavigation { get; set; }
}
