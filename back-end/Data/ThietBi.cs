using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ThietBi
{
    public int IdThietBi { get; set; }

    public string? TenThietBi { get; set; }

    public string? LoaiThietBi { get; set; }

    public string? TinhTrang { get; set; }

    public int? Gia { get; set; }

    public int? SoLuong { get; set; }

    public int IdPhong { get; set; }

    public virtual ICollection<ChiTietBaoTri> ChiTietBaoTris { get; set; } = new List<ChiTietBaoTri>();

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
