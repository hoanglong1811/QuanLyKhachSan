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
        // Không chứa navigation property hoặc danh sách lồng nhau để tránh vòng lặp tuần hoàn
    }

    public class AddTaiKhoan
    {
        public string TenDangNhap { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
    }
    public class UpdateTaiKhoan
    {
        public int IdTaiKhoan { get; set; }
        public string? TenDangNhap { get; set; }
        public string? Email { get; set; }
        public string? MatKhau { get; set; }
        // Nếu muốn cho phép cập nhật vai trò, thêm dòng sau:
        // public int? IdVaiTro { get; set; }
    }
}