namespace back_end.ViewModels
{
    public class NhanVienVM
    {
        public int IdNhanVien { get; set; }
        public string? TenNhanVien { get; set; }
        public string? ChucVu { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public DateTime NgayTuyenDung { get; set; }
        public decimal Luong { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
