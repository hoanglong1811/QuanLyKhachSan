namespace back_end.ViewModels
{
    public class KhachHangVM
    {
        public int IdKhachHang { get; set; }
        public string? HoTen { get; set; }
        public int? DienThoai { get; set; }
        public string? Cccd { get; set; }      

        public string? IdDatPhong { get; set; }
        public string? TenDatPhong { get; set; }
        public string? NgayDatPhong { get; set; }
        public string? NgayTraPhong { get; set; }
        public string? TrangThaiDatPhong { get; set; }

        public string? TenPhong { get; set; }
        public string? TenLoaiPhong { get; set; }
        public string? TenNhanVien { get; set; }
       
        

    }

    public class AddKhachHang
    {
        public string? HoTen { get; set; } = null!;
        public int? DienThoai { get; set; } = null!;
        public string? Cccd { get; set; } = null!;
    }
    public class UpdateKhachHang{
        public string? HoTen { get; set; } = null!;
        public int? DienThoai { get; set; } = null!;
        public string? Cccd { get; set; } = null!;
    }
}
