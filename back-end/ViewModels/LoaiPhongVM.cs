using System.ComponentModel.DataAnnotations;

namespace back_end.ViewModels
{
    public class LoaiPhongVM
    {
        public int IdLoaiPhong { get; set; }
        public string? TenLoaiPhong { get; set; }
        public string? MoTa { get; set; }
        public int? Gia { get; set; }

        public string? IdPhong { get; set; }
        public string? SoPhong { get; set; }

    }

    public class AddLoaiPhong
    {
        public string? TenLoaiPhong { get; set; } = null!;

        public int Gia { get; set; }

        public string? MoTa { get; set; }
    }

    public class UpdateLoaiPhong
    {
        public string? TenLoaiPhong { get; set; } = null!;

        public int? Gia { get; set; }

        public string? MoTa { get; set; }
    }
}
