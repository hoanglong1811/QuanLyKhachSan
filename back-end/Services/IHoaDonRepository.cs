using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IHoaDonRepository
    {
        Task<IEnumerable<HoaDonVM>> GetAllAsync();
        Task<HoaDonVM?> GetByIdAsync(int id);
        Task<HoaDonVM> AddAsync(AddHoaDon entity);
        Task<bool> UpdateAsync(int id, UpdateHoaDon entity);
        Task<bool> DeleteAsync(int id);
    }

    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public HoaDonRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HoaDonVM>> GetAllAsync()
        {
            return await _context.HoaDons.Select(hd => new HoaDonVM
            {
                IdHoaDon = hd.IdHoaDon,
                IdDatPhong = hd.IdDatPhong,
                NgayTao = hd.NgayTao,
                IdNhanVien = hd.IdNhanVien,
                PhuongThucThanhToan = hd.PhuongThucThanhToan,
                TrangThaiThanhToan = hd.TrangThaiThanhToan,
                TongTien = hd.TongTien,
                HoTen = hd.IdDatPhongNavigation.IdKhachHangNavigation.HoTen,
                DienThoai = hd.IdDatPhongNavigation.IdKhachHangNavigation.DienThoai,
                Cccd = hd.IdDatPhongNavigation.IdKhachHangNavigation.Cccd,
            }).ToListAsync();
        }

        public async Task<HoaDonVM?> GetByIdAsync(int id)
        {
            return await _context.HoaDons
                .Where(hd => hd.IdHoaDon == id)
                .Select(hd => new HoaDonVM
                {
                    IdHoaDon = hd.IdHoaDon,
                    IdDatPhong = hd.IdDatPhong,
                    NgayTao = hd.NgayTao,
                    IdNhanVien = hd.IdNhanVien,
                    PhuongThucThanhToan = hd.PhuongThucThanhToan,
                    TrangThaiThanhToan = hd.TrangThaiThanhToan,
                    TongTien = hd.TongTien,
                    HoTen = hd.IdDatPhongNavigation.IdKhachHangNavigation.HoTen,
                    DienThoai = hd.IdDatPhongNavigation.IdKhachHangNavigation.DienThoai,
                    Cccd = hd.IdDatPhongNavigation.IdKhachHangNavigation.Cccd,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<HoaDonVM> AddAsync(AddHoaDon entity)
        {
            var hoaDon = new HoaDon
            {
                IdDatPhong = entity.IdDatPhong,
                NgayTao = entity.NgayTao,
                IdNhanVien = entity.IdNhanVien,
                PhuongThucThanhToan = entity.PhuongThucThanhToan,
                TrangThaiThanhToan = entity.TrangThaiThanhToan,
                TongTien = entity.TongTien,
            };
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            return new HoaDonVM
            {
                IdHoaDon = hoaDon.IdHoaDon,
                IdDatPhong = hoaDon.IdDatPhong,
                NgayTao = hoaDon.NgayTao,
                IdNhanVien = hoaDon.IdNhanVien,
                PhuongThucThanhToan = hoaDon.PhuongThucThanhToan,
                TrangThaiThanhToan = hoaDon.TrangThaiThanhToan,
                TongTien = hoaDon.TongTien,
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateHoaDon entity)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null) return false;

            hoaDon.IdDatPhong = entity.IdDatPhong;
            hoaDon.NgayTao = entity.NgayTao;
            hoaDon.IdNhanVien = entity.IdNhanVien;
            hoaDon.PhuongThucThanhToan = entity.PhuongThucThanhToan;
            hoaDon.TrangThaiThanhToan = entity.TrangThaiThanhToan;
            hoaDon.TongTien = entity.TongTien;

            _context.HoaDons.Update(hoaDon);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.HoaDons.FindAsync(id);
            if (entity == null) return false;

            _context.HoaDons.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
