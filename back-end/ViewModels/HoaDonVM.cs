namespace back_end.ViewModels
{
    public class HoaDonVM
    {
        public int IdHoaDon { get; set; }
        public int IdDatPhong { get; set; }
        public DateTime? NgayTao { get; set; }
        public int IdNhanVien { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThaiThanhToan { get; set; }
        public int? TongTien { get; set; }
        
        // Additional view model properties
        public string? TenNhanVien { get; set; }
        public string? TenKhachHang { get; set; }
        public List<ChiTietHoaDonVM>? ChiTietHoaDons { get; set; }
    }
    public class AddHoaDon
    {
        public int IdDatPhong { get; set; }
        public DateTime? NgayTao { get; set; }
        public int IdNhanVien { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThaiThanhToan { get; set; }
    }
    public class UpdateHoaDon
    {
        public int IdDatPhong { get; set; }
        public DateTime? NgayTao { get; set; }
        public int IdNhanVien { get; set; }
        public string? PhuongThucThanhToan { get; set; }
        public string? TrangThaiThanhToan { get; set; }
    }
}
