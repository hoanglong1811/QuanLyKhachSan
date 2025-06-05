namespace back_end.ViewModels
{
    public class ChiTietDatPhongVM
    {
        public int IdChiTietDatPhong { get; set; }
        public int IdPhong { get; set; }
        public int IdDatPhong { get; set; }
        public int IdKhachHang { get; set; }
        public DateTime? NgayDatPhong { get; set; }
        public DateTime? NgayTraPhong { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public int? SoLuongNguoi { get; set; }
        public int IdChiTietDichVu { get; set; }
        public int? ThanhTien { get; set; }
        // Thêm các thuộc tính mở rộng nếu cần, ví dụ:
        public string? TenKhachHang { get; set; }
        public string? TenPhong { get; set; }
        public string? TenDichVu { get; set; }
    }
}
