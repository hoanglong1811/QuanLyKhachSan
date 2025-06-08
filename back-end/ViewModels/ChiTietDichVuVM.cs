namespace back_end.ViewModels
{
    public class ChiTietDichVuVM
    {
        public int IdChiTietDichVu { get; set; }

        public int IdDichVu { get; set; }

        public int? SoLuong { get; set; }

        public int? TongTien { get; set; }
    }
    public class AddChiTietDichVu
    {
        public int IdDichVu { get; set; }

        public int? SoLuong { get; set; }

        public int? TongTien { get; set; }
    }
    public class UpdateChiTietDichVu
    {

        public int IdDichVu { get; set; }

        public int? SoLuong { get; set; }

        public int? TongTien { get; set; }
    }

}
