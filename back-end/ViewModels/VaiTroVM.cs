namespace back_end.ViewModels
{
    public class VaiTroVM
    {
        public int IdVaiTro { get; set; }
        public string? TenVaiTro { get; set; }
        public string? MoTa { get; set; }
        
    }


    public class AddVaiTro
    {
        public string TenVaiTro { get; set; } = null!;
        public string? MoTa { get; set; }

    }
    
    public class UpdateVaiTro
    {
        public string TenVaiTro { get; set; } = null!;
        public string? MoTa { get; set; }
        
    }
}
