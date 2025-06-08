namespace back_end.ViewModels
{
    public class ChiTietBaoTriVM
    {
        public int IdChiTietBaoTri { get; set; }

        public int IdThietBi { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public int? SoLuongThietBi { get; set; }

        public int IdPhieuBaoTri { get; set; }
    }

    public class AddChiTietBaoTri
    {
        public int IdThietBi { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public int? SoLuongThietBi { get; set; }

        public int IdPhieuBaoTri { get; set; }
    }
    public class UpdateChiTietBaoTri
    {
        public int IdChiTietBaoTri { get; set; }
        public int IdThietBi { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? SoLuongThietBi { get; set; }
        public int IdPhieuBaoTri { get; set; }
    }
}
