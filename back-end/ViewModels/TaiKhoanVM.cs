namespace back_end.ViewModels
{
    public class TaiKhoanVM
    {
        public int? IdTaiKhoan { get; set; } // Cho phép null khi tạo mới
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }
        public int IdVaiTro { get; set; }
        public string? TenVaiTro { get; set; }
        
    }

    public class AddTaiKhoan
    {
        public string TenDangNhap { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
    }
    public class UpdateTaiKhoan
    {
        
        public string? TenDangNhap { get; set; }
        public string? Email { get; set; }
        public string? MatKhau { get; set; }
    }
}