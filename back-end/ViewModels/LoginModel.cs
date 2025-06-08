using System.ComponentModel.DataAnnotations;

namespace back_end.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhau { get; set; }
    }

    public class LoginResponse
    {
        public int IdTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string Email { get; set; }
        public int IdVaiTro { get; set; }
        public string TenVaiTro { get; set; }
    }
} 