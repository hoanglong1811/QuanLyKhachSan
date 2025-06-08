namespace back_end.ViewModels
{
    public class ChiTietHoaDonVM
    {
        public int IdChiTietHoaDon { get; set; }
        public int IdHoaDon { get; set; }
        public int IdDatPhong { get; set; }
        public int IdChiTietDichVu { get; set; }
        public string? MoTa { get; set; }
        public int? ThanhTien { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? GhiChu { get; set; }

        // Additional view model properties
        public string? TenDichVu { get; set; }
        public string? TenPhong { get; set; }
    }
} 