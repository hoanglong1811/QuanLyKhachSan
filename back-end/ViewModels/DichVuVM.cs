namespace back_end.ViewModels
{
    public class DichVuVM
    {
        public int IdDichVu { get; set; }
        public string? TenDichVu { get; set; }
        public int? Gia { get; set; }
        public string? DonViTinh { get; set; }
        public string? MoTa { get; set; }
    }

    public class AddDichVu{
        public string? TenDichVu { get; set; }
        public int? Gia { get; set; }
        public string? DonViTinh { get; set; }
        public string? MoTa { get; set; }
    }
    public class UpdateDichVu{
        public string? TenDichVu { get; set; }
        public int? Gia { get; set; }
        public string? DonViTinh { get; set; }
        public string? MoTa { get; set; } 
    }
}
