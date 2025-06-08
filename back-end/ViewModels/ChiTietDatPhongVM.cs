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

        public int? ThanhTien { get; set; }
    }

    public class AddChiTietDatPhong
    {
        public int IdPhong { get; set; }

        public int IdDatPhong { get; set; }

        public int IdKhachHang { get; set; }

        public DateTime? NgayDatPhong { get; set; }

        public DateTime? NgayTraPhong { get; set; }

        public string? PhuongThucThanhToan { get; set; }

        public int? SoLuongNguoi { get; set; }

        public int? ThanhTien { get; set; }
    }
    public class UpdateChiTietDatPhong
        {
            public int IdChiTietDatPhong { get; set; }
    
            public int IdPhong { get; set; }
    
            public int IdDatPhong { get; set; }
    
            public int IdKhachHang { get; set; }
    
            public DateTime? NgayDatPhong { get; set; }
    
            public DateTime? NgayTraPhong { get; set; }
    
            public string? PhuongThucThanhToan { get; set; }
    
            public int? SoLuongNguoi { get; set; }
    
            public int? ThanhTien { get; set; }
        }
}
