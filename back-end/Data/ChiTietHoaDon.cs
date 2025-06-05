using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ChiTietHoaDon
{
    public int IdChiTietHoaDon { get; set; }

    public int IdHoaDon { get; set; }

    public int IdDatPhong { get; set; }

    public int IdChiTietDichVu { get; set; }

    public string? MoTa { get; set; }

    public int? ThanhTien { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? GhiChu { get; set; }

    public virtual ChiTietDichVu IdChiTietDichVuNavigation { get; set; } = null!;

    public virtual DatPhong IdDatPhongNavigation { get; set; } = null!;

    public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;
}
