using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class PhieuBaoTri
{
    public int IdPhieuBaoTri { get; set; }

    public string? MoTaVanDe { get; set; }

    public int IdNhanVien { get; set; }

    public int IdChiTietBaoTri { get; set; }

    public virtual ChiTietBaoTri IdChiTietBaoTriNavigation { get; set; } = null!;
}
