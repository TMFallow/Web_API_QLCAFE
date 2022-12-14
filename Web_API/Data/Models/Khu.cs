using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Khu
{
    public string MaKhu { get; set; } = null!;

    public string? TenKhu { get; set; }

    public int? TinhTrang { get; set; }

    public virtual ICollection<Ban> Bans { get; } = new List<Ban>();
}
