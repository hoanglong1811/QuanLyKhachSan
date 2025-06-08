namespace back_end.ViewModels
{
    public class DatPhongVM
    {
        public int IdDatPhong { get; set; }

        public DateTime? NgayDatPhong { get; set; }

        public DateTime? NgayTraPhong { get; set; }

        public string? TrangThaiDatPhong { get; set; }

        public string? GhiChu { get; set; }

        public int IdKhachHang { get; set; }
    }

    public class AddDatPhong
    {
        public DateTime? NgayDatPhong { get; set; }

        public DateTime? NgayTraPhong { get; set; }

        public string? TrangThaiDatPhong { get; set; }

        public string? GhiChu { get; set; }

        public int IdKhachHang { get; set; }
    }
    public class UpdateDatPhong
    {
        public int IdDatPhong { get; set; }

        public DateTime? NgayDatPhong { get; set; }

        public DateTime? NgayTraPhong { get; set; }

        public string? TrangThaiDatPhong { get; set; }

        public string? GhiChu { get; set; }

        public int IdKhachHang { get; set; }
    }
}
