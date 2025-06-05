using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class PhieuBaoTri
{
    public int IdPhieuBaoTri { get; set; }

    public string? MoTaVanDe { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? TrangThai { get; set; }

    public int IdNhanVien { get; set; }

    public virtual ICollection<ChiTietBaoTri> ChiTietBaoTris { get; set; } = new List<ChiTietBaoTri>();

    public virtual NhanVien IdNhanVienNavigation { get; set; } = null!;
}
