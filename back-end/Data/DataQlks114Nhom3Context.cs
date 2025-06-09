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

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

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
            entity.HasKey(e => e.IdChiTietBaoTri);

            entity.ToTable("ChiTietBaoTri");

            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

            entity.HasOne(d => d.IdPhieuBaoTriNavigation).WithMany(p => p.ChiTietBaoTris)
                .HasForeignKey(d => d.IdPhieuBaoTri)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietBaoTri_PhieuBaoTri");

            entity.HasOne(d => d.IdThietBiNavigation).WithMany(p => p.ChiTietBaoTris)
                .HasForeignKey(d => d.IdThietBi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietBaoTri_ThietBi1");
        });

        modelBuilder.Entity<ChiTietDatPhong>(entity =>
        {
            entity.HasKey(e => e.IdChiTietDatPhong);

            entity.ToTable("ChiTietDatPhong");

            entity.Property(e => e.NgayDatPhong).HasColumnType("datetime");
            entity.Property(e => e.NgayTraPhong).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(255);

            entity.HasOne(d => d.IdDatPhongNavigation).WithMany(p => p.ChiTietDatPhongs)
                .HasForeignKey(d => d.IdDatPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDatPhong_DatPhong");

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.ChiTietDatPhongs)
                .HasForeignKey(d => d.IdKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDatPhong_KhachHang");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.ChiTietDatPhongs)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDatPhong_Phong");
        });

        modelBuilder.Entity<ChiTietDichVu>(entity =>
        {
            entity.HasKey(e => e.IdChiTietDichVu).HasName("PK_ChiTietDichVU");

            entity.ToTable("ChiTietDichVu");

            entity.HasOne(d => d.IdDichVuNavigation).WithMany(p => p.ChiTietDichVus)
                .HasForeignKey(d => d.IdDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDichVU_DichVu");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.IdChiTietHoaDon).HasName("PK_ChiTietHoaDon_1");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");

            entity.HasOne(d => d.IdChiTietDichVuNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdChiTietDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_ChiTietDichVU");

            entity.HasOne(d => d.IdDatPhongNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdDatPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_DatPhong");

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.IdDatPhong).HasName("PK_DatPhong_1");

            entity.ToTable("DatPhong");

            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.NgayDatPhong).HasColumnType("datetime");
            entity.Property(e => e.NgayTraPhong).HasColumnType("datetime");
            entity.Property(e => e.TrangThaiDatPhong).HasMaxLength(255);

            entity.HasOne(d => d.IdKhachHangNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.IdKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatPhong_KhachHang");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.IdDichVu).HasName("PK_DichVu_1");

            entity.ToTable("DichVu");

            entity.Property(e => e.DonViTinh).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenDichVu).HasMaxLength(255);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IdHoaDon).HasName("PK_HoaDon_1");

            entity.ToTable("HoaDon");

            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(255);
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(255);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKhachHang).HasName("PK_KhachHang_1");

            entity.ToTable("KhachHang");

            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.HoTen).HasMaxLength(255);
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiPhong).HasName("PK_LoaiPhong_1");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.MoTa).HasMaxLength(50);
            entity.Property(e => e.TenLoaiPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.IdNhanVien).HasName("PK_NhanVien_1");

            entity.ToTable("NhanVien");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(3);
            entity.Property(e => e.HoTen).HasMaxLength(255);

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
            entity.HasKey(e => e.IdPhanQuyen).HasName("PK_PhanQuyen_1");

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.TenQuyen).HasMaxLength(255);

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.IdVaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanQuyen_VaiTro");
        });

        modelBuilder.Entity<PhieuBaoTri>(entity =>
        {
            entity.HasKey(e => e.IdPhieuBaoTri);

            entity.ToTable("PhieuBaoTri");

            entity.Property(e => e.MoTaVanDe).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(255);

            entity.HasOne(d => d.IdNhanVienNavigation).WithMany(p => p.PhieuBaoTris)
                .HasForeignKey(d => d.IdNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuBaoTri_NhanVien");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.IdPhong);

            entity.ToTable("Phong");

            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdLoaiPhongNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdLoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_LoaiPhong");
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
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdVaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiKhoan_VaiTro");
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.HasKey(e => e.IdThietBi).HasName("PK_ThietBi_1");

            entity.ToTable("ThietBi");

            entity.Property(e => e.LoaiThietBi).HasMaxLength(255);
            entity.Property(e => e.TenThietBi).HasMaxLength(255);
            entity.Property(e => e.TinhTrang).HasMaxLength(255);

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.ThietBis)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThietBi_Phong");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.IdVaiTro).HasName("PK_VaiTro_1");

            entity.ToTable("VaiTro");

            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenVaiTro).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
