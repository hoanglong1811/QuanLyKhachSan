﻿namespace back_end.ViewModels
{
    public class ChiTietBaoTriVM
    {
        public int IdChiTietBaoTri { get; set; }
        public int IdThietBi { get; set; }
        public string? TenThietBi { get; set; }
        public string? LoaiBaoTri { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? SoLuongThietBi { get; set; }
    }
}
