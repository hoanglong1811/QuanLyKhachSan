namespace back_end.ViewModels
{
    public class ThietBiVM
    {
        public int IdThietBi { get; set; }
        public string? TenThietBi { get; set; }
        public string? LoaiThietBi { get; set; }
        public string? TinhTrang { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public int IdPhong { get; set; }
        public string? TenPhong { get; set; }
    }

    public class AddThietBi
    {
        
        public string? TenThietBi { get; set; }
        public string? LoaiThietBi { get; set; }
        public string? TinhTrang { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public int IdPhong { get; set; }
        
    }
     public class UpdateThietBi
    {        
        public string? TenThietBi { get; set; }
        public string? LoaiThietBi { get; set; }
        public string? TinhTrang { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        public int IdPhong { get; set; }        
    }
}
