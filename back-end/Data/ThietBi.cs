using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ThietBi
{
    public int IdThietBi { get; set; }

    public string? TenThietBi { get; set; }

    public string? TinhTrang { get; set; }

    public int IdPhong { get; set; }

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
