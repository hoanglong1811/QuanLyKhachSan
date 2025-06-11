namespace back_end.ViewModels
{
    public class DatPhongVM
    {
        public int IdDatPhong { get; set; }       

        public int IdKhachHang { get; set; }
    }

    public class AddDatPhong   
     {
        
        public int IdKhachHang { get; set; }
    }
    public class UpdateDatPhong
    {
        public int IdDatPhong { get; set; }        

        public int IdKhachHang { get; set; }
    }
}
