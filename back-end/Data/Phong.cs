using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Phong
{
    public int IdPhong { get; set; }

    public int IdLoaiPhong { get; set; }

    public int? SoPhong { get; set; }

    public string? TrangThai { get; set; }

    public virtual LoaiPhong IdLoaiPhongNavigation { get; set; } = null!;

    public virtual ICollection<ThietBi> ThietBis { get; set; } = new List<ThietBi>();
}
