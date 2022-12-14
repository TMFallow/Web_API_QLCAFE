using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? TenNv { get; set; }

    public string? MatKhau { get; set; }

    public string? MatKhauCap2 { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? ChucVu { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? HinhAnh { get; set; }

    public int? TinhTrang { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual PhanQuyen? PhanQuyen { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; } = new List<PhieuNhap>();
}
