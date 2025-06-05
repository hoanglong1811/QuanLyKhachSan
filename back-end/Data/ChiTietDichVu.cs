using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ChiTietDichVu
{
    public int IdChiTietDichVu { get; set; }

    public int IdDichVu { get; set; }

    public int? SoLuong { get; set; }

    public int? TongTien { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DichVu IdDichVuNavigation { get; set; } = null!;
}
