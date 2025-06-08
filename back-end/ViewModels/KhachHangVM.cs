namespace back_end.ViewModels
{
    public class KhachHangVM
    {
        public int IdKhachHang { get; set; }
        public string? HoTen { get; set; }
        public int? DienThoai { get; set; }
        public string? Cccd { get; set; }      



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
