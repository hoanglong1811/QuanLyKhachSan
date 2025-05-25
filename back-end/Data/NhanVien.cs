using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class NhanVien
{
    public int IdNhanVien { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; }

    public string? GioiTinh { get; set; }

    public int? DienThoai { get; set; }

    public int IdTaiKhoan { get; set; }

    public virtual TaiKhoan IdTaiKhoanNavigation { get; set; } = null!;
}
