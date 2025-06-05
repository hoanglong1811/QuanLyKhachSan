using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ChiTietBaoTri
{
    public int IdChiTietBaoTri { get; set; }

    public int IdThietBi { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public int? SoLuongThietBi { get; set; }

    public int IdPhieuBaoTri { get; set; }

    public virtual PhieuBaoTri IdPhieuBaoTriNavigation { get; set; } = null!;

    public virtual ThietBi IdThietBiNavigation { get; set; } = null!;
}
