namespace back_end.ViewModels
{
    public class PhongVM
    {
        public int IdPhong { get; set; }
        public int IdLoaiPhong { get; set; }
        public int? SoPhong { get; set; }
        public int? SucChua { get; set; }
        public string? TrangThai { get; set; }
        
    }
    
    public class AddPhong
    {
        
        public int IdLoaiPhong { get; set; }
        public int? SoPhong { get; set; }
        public int? SucChua { get; set; }
        public string? TrangThai { get; set; }
             
    }
    public class UpdatePhong
    {
        
        public int IdLoaiPhong { get; set; }
        public int? SoPhong { get; set; }
        public int? SucChua { get; set; }
        public string? TrangThai { get; set; }
        
    }
}
