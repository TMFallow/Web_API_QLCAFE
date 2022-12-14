using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class QlCafe2Context : DbContext
{
    public QlCafe2Context()
    {
    }

    public QlCafe2Context(DbContextOptions<QlCafe2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<ChiTietDh> ChiTietDhs { get; set; }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<ChiTietPn> ChiTietPns { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<Datum> Data { get; set; }

    public virtual DbSet<DonDatHang> DonDatHangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Khu> Khus { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-O3QUUSD1\\SQLEXPRESS;Database=QL_CAFE2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.MaBan);

            entity.ToTable("Ban");

            entity.Property(e => e.MaBan)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKhu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayDatBan).HasColumnType("date");
            entity.Property(e => e.TenBan).HasMaxLength(50);

            entity.HasOne(d => d.MaKhuNavigation).WithMany(p => p.Bans)
                .HasForeignKey(d => d.MaKhu)
                .HasConstraintName("FK_Ban_Khu");
        });

        modelBuilder.Entity<ChiTietDh>(entity =>
        {
            entity.HasKey(e => new { e.MaDonHang, e.MaNl });

            entity.ToTable("ChiTietDH");

            entity.Property(e => e.MaDonHang)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNl)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNL");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietDhs)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDH_DonDatHang");

            entity.HasOne(d => d.MaNlNavigation).WithMany(p => p.ChiTietDhs)
                .HasForeignKey(d => d.MaNl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDH_NguyenLieu");
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp });

            entity.ToTable("ChiTietHD");

            entity.Property(e => e.MaHd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.MaSp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHD_HoaDon");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHD_SanPham");
        });

        modelBuilder.Entity<ChiTietPn>(entity =>
        {
            entity.HasKey(e => new { e.MaDonHang, e.MaNl });

            entity.ToTable("ChiTietPN");

            entity.Property(e => e.MaDonHang)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNl)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNL");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietPns)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietPN_PhieuNhap");

            entity.HasOne(d => d.Ma).WithOne(p => p.ChiTietPn)
                .HasForeignKey<ChiTietPn>(d => new { d.MaDonHang, d.MaNl })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietPN_ChiTietDH");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaNl });

            entity.ToTable("ChiTietSanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.MaNl)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNL");

            entity.HasOne(d => d.MaNlNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaNl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietSanPham_NguyenLieu");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietSanPham_SanPham");
        });

        modelBuilder.Entity<Datum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DATA");

            entity.Property(e => e.Nam).HasColumnName("NAM");
            entity.Property(e => e.Thang).HasColumnName("THANG");
        });

        modelBuilder.Entity<DonDatHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang);

            entity.ToTable("DonDatHang");

            entity.Property(e => e.MaDonHang)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.MaNcc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.NgayDatHang).HasColumnType("datetime");
            entity.Property(e => e.TinhTrang).HasMaxLength(100);
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.DonDatHangs)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_DonDatHang_NhaCungCap");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK_HoaDon_KhuyenMai");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHD");
            entity.Property(e => e.MaBan)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKh)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.MaKhuyenMai)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayLap).HasColumnType("datetime");
            entity.Property(e => e.NguoiLap)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TienKhachDua).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TienThua).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaBanNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaBan)
                .HasConstraintName("FK_HoaDon_Ban");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_HoaDon_KhachHang");

            entity.HasOne(d => d.MaKhuyenMaiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhuyenMai)
                .HasConstraintName("FK_HoaDon_KhuyenMai");

            entity.HasOne(d => d.NguoiLapNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.NguoiLap)
                .HasConstraintName("FK_HoaDon_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<Khu>(entity =>
        {
            entity.HasKey(e => e.MaKhu);

            entity.ToTable("Khu");

            entity.Property(e => e.MaKhu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenKhu).HasMaxLength(20);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenMai);

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKhuyenMai)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DieuKien).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("LoaiSP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<NguyenLieu>(entity =>
        {
            entity.HasKey(e => e.MaNl);

            entity.ToTable("NguyenLieu");

            entity.Property(e => e.MaNl)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNL");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Dvt)
                .HasMaxLength(10)
                .HasColumnName("DVT");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MaNcc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.TenNl)
                .HasMaxLength(50)
                .HasColumnName("TenNL");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.NguyenLieus)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_NguyenLieu_NhaCungCap");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc);

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(50)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK_NhanVien_1");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MatKhauCap2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNV");
            entity.Property(e => e.PhanQuyen1).HasColumnName("PhanQuyen");

            entity.HasOne(d => d.MaNvNavigation).WithOne(p => p.PhanQuyen)
                .HasForeignKey<PhanQuyen>(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanQuyen_NhanVien");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaDonHang);

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.MaDonHang)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayGiaoHang).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDonHangNavigation).WithOne(p => p.PhieuNhap)
                .HasForeignKey<PhieuNhap>(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuNhap_DonDatHang");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_PhieuNhap_NhanVien");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MaLoai)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_SanPham_LoaiSP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
