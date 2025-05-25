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
} 