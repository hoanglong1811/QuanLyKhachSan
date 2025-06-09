namespace back_end.ViewModels
{
    public class PhieuBaoTriVM
    {
        public int IdPhieuBaoTri { get; set; }

        public string? MoTaVanDe { get; set; }

        public DateTime? NgayTao { get; set; }

        public string? TrangThai { get; set; }

        public int IdNhanVien { get; set; }

    }

    public class AddPhieuBaoTri
    {
        public string? MoTaVanDe { get; set; }

        public DateTime? NgayTao { get; set; }

        public string? TrangThai { get; set; }

        public int IdNhanVien { get; set; }

    }
    public class UpdatePhieuBaoTri
    {
        public string? MoTaVanDe { get; set; }

        public DateTime? NgayTao { get; set; }

        public string? TrangThai { get; set; }

        public int IdNhanVien { get; set; }
    }
}
