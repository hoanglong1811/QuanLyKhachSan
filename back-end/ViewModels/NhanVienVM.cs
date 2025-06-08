namespace back_end.ViewModels
{
    public class NhanVienVM
    {
        public int IdNhanVien { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public int? DienThoai { get; set; }
        public int IdTaiKhoan { get; set; }
        public string? TenTaiKhoan { get; set; }
        public string? Email { get; set; }
        public string? VaiTro { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class AddNhanVien
    {
        public string HoTen { get; set; } = null!;
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public int? DienThoai { get; set; }
        public int IdTaiKhoan { get; set; }
    }

    public class UpdateNhanVien
    {
        public string HoTen { get; set; } = null!;
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public int? DienThoai { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
