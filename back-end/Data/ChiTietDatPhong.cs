using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ChiTietDatPhong
{
    public int IdChiTietDatPhong { get; set; }

    public int IdPhong { get; set; }

    public int IdDatPhong { get; set; }

    public int IdKhachHang { get; set; }

    public DateTime? NgayDatPhong { get; set; }

    public DateTime? NgayTraPhong { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public int? SoLuongNguoi { get; set; }

    public int? ThanhTien { get; set; }

    public virtual DatPhong IdDatPhongNavigation { get; set; } = null!;

    public virtual KhachHang IdKhachHangNavigation { get; set; } = null!;

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
