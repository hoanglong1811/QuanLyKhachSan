using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data;

public partial class DataQlks114Nhom3Context : DbContext
{
    public DataQlks114Nhom3Context()
    {
    }

    public DataQlks114Nhom3Context(DbContextOptions<DataQlks114Nhom3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietBaoTri> ChiTietBaoTris { get; set; }

    public virtual DbSet<ChiTietDatPhong> ChiTietDatPhongs { get; set; }

    public virtual DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<OtaIntegration> OtaIntegrations { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<PhieuBaoTri> PhieuBaoTris { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThietBi> ThietBis { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=118.69.126.49;Initial Catalog=data_QLKS_114_Nhom3;User ID=user_114_nhom3;Password=123456789;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietBaoTri>(entity =>
        {
            entity.HasKey(e => e.IdChiTietBaoTri).HasName("PK_ChiTietBaoTri_1");

            entity.ToTable("ChiTietBaoTri");

            entity.Property(e => e.LoaiBaoTri).HasMaxLength(50);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TenThietBi).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiTietDatPhong>(entity =>
        {
            entity.HasKey(e => new { e.IdChiTietDatPhong, e.IdPhong, e.IdDatPhong, e.IdKhachHang, e.IdChiTietDichVu });

            entity.ToTable("ChiTietDatPhong");

            entity.Property(e => e.IdChiTietDatPhong).ValueGeneratedOnAdd();
            entity.Property(e => e.NgayDatPhong).HasColumnType("datetime");
            entity.Property(e => e.NgayTraPhong).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.ChiTietDatPhongs)
                .HasForeignKey(d => d.IdKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDatPhong_KhachHang");
        });

        modelBuilder.Entity<ChiTietDichVu>(entity =>
        {
            entity.HasKey(e => new { e.IdChiTietDichVu, e.IdDichVu });

            entity.ToTable("ChiTietDichVU");

            entity.Property(e => e.IdChiTietDichVu).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdDichVuNavigation).WithMany(p => p.ChiTietDichVus)
                .HasForeignKey(d => d.IdDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDichVU_DichVu");
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => new { e.IdDatPhong, e.IdKhachHang }).HasName("PK_DatPhong_1");

            entity.ToTable("DatPhong");

            entity.Property(e => e.IdDatPhong).ValueGeneratedOnAdd();
            entity.Property(e => e.NgayDatPhong).HasColumnType("datetime");
            entity.Property(e => e.NgayTraPhong).HasColumnType("datetime");

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.IdKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatPhong_KhachHang");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.IdDichVu);

            entity.ToTable("DichVu");

            entity.Property(e => e.MoTa).HasMaxLength(50);
            entity.Property(e => e.TenDichVu).HasMaxLength(50);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHoaDon).HasName("PK_HoaDon_1");

            entity.ToTable("HoaDon");

            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKhachHang);

            entity.ToTable("KhachHang");

            entity.Property(e => e.Cccd).HasColumnName("CCCD");
            entity.Property(e => e.HoTen).HasMaxLength(50);
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiPhong);

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.MoTa).HasMaxLength(50);
            entity.Property(e => e.TenLoaiPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => new { e.IdNhanVien, e.IdTaiKhoan }).HasName("PK_NhanVien_1");

            entity.ToTable("NhanVien");

            entity.Property(e => e.IdNhanVien).ValueGeneratedOnAdd();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(3);
            entity.Property(e => e.HoTen).HasMaxLength(50);

            entity.HasOne(d => d.IdTaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_TaiKhoan");
        });

        modelBuilder.Entity<OtaIntegration>(entity =>
        {
            entity.HasKey(e => e.IdTichHop);

            entity.ToTable("OTA_Integration");

            entity.Property(e => e.IdTichHop).ValueGeneratedNever();
            entity.Property(e => e.Apikey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APIKey");
            entity.Property(e => e.Otaname)
                .HasMaxLength(50)
                .HasColumnName("OTAname");
            entity.Property(e => e.ThoiGianDongBo).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => new { e.IdPhanQuyen, e.IdVaiTro }).HasName("PK_PhanQuyen_1");

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.IdPhanQuyen).ValueGeneratedOnAdd();
            entity.Property(e => e.TenQuyen).HasMaxLength(50);

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.IdVaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanQuyen_VaiTro");
        });

        modelBuilder.Entity<PhieuBaoTri>(entity =>
        {
            entity.HasKey(e => new { e.IdPhieuBaoTri, e.IdNhanVien, e.IdChiTietBaoTri }).HasName("PK_PhieuBaoTri_1");

            entity.ToTable("PhieuBaoTri");

            entity.Property(e => e.IdPhieuBaoTri).ValueGeneratedOnAdd();
            entity.Property(e => e.MoTaVanDe).HasMaxLength(50);

            entity.HasOne(d => d.IdChiTietBaoTriNavigation).WithMany(p => p.PhieuBaoTris)
                .HasForeignKey(d => d.IdChiTietBaoTri)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuBaoTri_ChiTietBaoTri");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.IdPhong);

            entity.ToTable("Phong");

            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdLoaiPhongNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdLoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_LoaiPhong1");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdTaiKhoan).HasName("PK_TaiKhoan_1");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdVaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiKhoan_VaiTro");
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.HasKey(e => new { e.IdThietBi, e.IdPhong }).HasName("PK_ThietBi_1");

            entity.ToTable("ThietBi");

            entity.Property(e => e.IdThietBi).ValueGeneratedOnAdd();
            entity.Property(e => e.TenThietBi).HasMaxLength(50);
            entity.Property(e => e.TinhTrang).HasMaxLength(50);

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.ThietBis)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThietBi_Phong");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.IdVaiTro);

            entity.ToTable("VaiTro");

            entity.Property(e => e.MoTa).HasMaxLength(50);
            entity.Property(e => e.TenVaiTro).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
