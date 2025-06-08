namespace back_end.ViewModels
{
    public class PhieuBaoTriVM
    {
        public int Id { get; set; }
        public int ThietBiId { get; set; }
        public DateTime NgayBaoTri { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }

        public string? TenNhanVien { get; set; }
        public string? TenThietBi { get; set; }
        public string? SoPhong { get; set; }
    }

    public class AddPhieuBaoTri
    {
        public int ThietBiId { get; set; }
        public DateTime NgayBaoTri { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }

    }
    public class UpdatePhieuBaoTri
    {
        public int ThietBiId { get; set; }
        public DateTime NgayBaoTri { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }
    }
}
