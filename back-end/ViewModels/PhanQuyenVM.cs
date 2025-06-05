namespace back_end.ViewModels
{
    public class PhanQuyenVM
    {
        public int Id { get; set; }
        public string? TenQuyen { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? NguoiTao { get; set; }
        public string? NguoiCapNhat { get; set; }
    }
}
