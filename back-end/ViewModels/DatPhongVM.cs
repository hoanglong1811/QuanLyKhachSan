namespace back_end.ViewModels
{
    public class DatPhongVM
    {
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int PhongId { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayTra { get; set; }
        public decimal TongTien { get; set; }
    }
}
