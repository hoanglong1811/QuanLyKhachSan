using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class LoaiPhong
{
    public int IdLoaiPhong { get; set; }

    public string? TenLoaiPhong { get; set; }

    public string? MoTa { get; set; }

    public int? Gia { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
