using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class HoaDon
{
    public int IdHoaDon { get; set; }

    public int IdDatPhong { get; set; }

    public DateTime? NgayTao { get; set; }

    public int IdNhanVien { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? TrangThaiThanhToan { get; set; }

    public int? TongTien { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
