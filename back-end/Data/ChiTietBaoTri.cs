using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ChiTietBaoTri
{
    public int IdChiTietBaoTri { get; set; }

    public int IdThietBi { get; set; }

    public string? TenThietBi { get; set; }

    public string? LoaiBaoTri { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public int? SoLuongThietBi { get; set; }

    public virtual ICollection<PhieuBaoTri> PhieuBaoTris { get; set; } = new List<PhieuBaoTri>();
}
