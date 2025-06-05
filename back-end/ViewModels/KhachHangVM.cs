namespace back_end.ViewModels
{
    public class KhachHangVM
    {
        public int IdKhachHang { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? GhiChu { get; set; }
        public bool? GioiTinh { get; set; } // true: Nam, false: Nữ
    }
}
