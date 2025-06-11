using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class DatPhong
{
    public int IdDatPhong { get; set; }    

    public int IdKhachHang { get; set; }

    public virtual ICollection<ChiTietDatPhong> ChiTietDatPhongs { get; set; } = new List<ChiTietDatPhong>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang IdKhachHangNavigation { get; set; } = null!;
}
