namespace back_end.ViewModels
{
    public class PhanQuyenVM
    {
        public int IdPhanQuyen { get; set; }
        public string? TenQuyen { get; set; }
        public int IdVaiTro { get; set; }
        public bool? QuyenHan { get; set; }
        public string? TenVaiTro { get; set; }
    }

    public class AddPhanQuyen
    {
        public string? TenQuyen { get; set; }
        public int IdVaiTro { get; set; }
        public bool? QuyenHan { get; set; }
    }
    
    public class UpdatePhanQuyen
    {
        public string? TenQuyen { get; set; }
        public int IdVaiTro { get; set; }
        public bool? QuyenHan { get; set; }
    }
}
