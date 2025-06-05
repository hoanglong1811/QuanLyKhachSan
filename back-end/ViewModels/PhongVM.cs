namespace back_end.ViewModels
{
    public class PhongVM
    {
        public int IdPhong { get; set; }
        public string? TenPhong { get; set; }
        public int? SoLuongGiuong { get; set; }
        public int? SoLuongKhachToiDa { get; set; }
        public decimal? Gia { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh { get; set; }
        public string? TrangThai { get; set; } // true: Đang sử dụng, false: Chưa sử dụng
    }
}
