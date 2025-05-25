using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class DichVu
{
    public int IdDichVu { get; set; }

    public string? TenDichVu { get; set; }

    public string? MoTa { get; set; }

    public int? Gia { get; set; }

    public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; } = new List<ChiTietDichVu>();
}
