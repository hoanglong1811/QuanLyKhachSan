using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class DatPhong
{
    public int IdDatPhong { get; set; }

    public DateTime? NgayDatPhong { get; set; }

    public DateTime? NgayTraPhong { get; set; }

    public int IdKhachHang { get; set; }

    public virtual KhachHang IdKhachHangNavigation { get; set; } = null!;
}
