using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class PhanQuyen
{
    public string MaNv { get; set; } = null!;

    public bool? NhaCungCap { get; set; }

    public bool? NhanVien { get; set; }

    public bool? HangHoa { get; set; }

    public bool? BaoCao { get; set; }

    public bool? PhanQuyen1 { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
