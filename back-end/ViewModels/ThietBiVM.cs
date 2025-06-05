namespace back_end.ViewModels
{
    public class ThietBiVM
    {
        public int IdThietBi { get; set; }
        public string? TenThietBi { get; set; }
        public string? LoaiThietBi { get; set; }
        public string? MoTa { get; set; }
        public DateTime? NgayNhap { get; set; }
        public int? SoLuong { get; set; }
        public string? TinhTrang { get; set; }
        public string? NhaCungCap { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
    }
}
