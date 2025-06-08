using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.ViewModels;

namespace back_end.Services
{
    public interface IChiTietDatPhongRepository
    {
        Task<IEnumerable<ChiTietDatPhongVM>> GetAllAsync();
        Task<ChiTietDatPhongVM?> GetByIdAsync(int id);
        Task<ChiTietDatPhongVM> AddAsync(AddChiTietDatPhong model);
        Task<bool> UpdateAsync(int id, UpdateChiTietDatPhong model);
        Task<bool> DeleteAsync(int id);
    }

    public class ChiTietDatPhongRepository : IChiTietDatPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietDatPhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietDatPhongVM>> GetAllAsync()
        {
            return await _context.ChiTietDatPhongs.Select(c => new ChiTietDatPhongVM
            {
                IdChiTietDatPhong = c.IdChiTietDatPhong,

                IdPhong = c.IdPhong,
                IdDatPhong = c.IdDatPhong,
                IdKhachHang = c.IdKhachHang,
                NgayDatPhong = c.NgayDatPhong,
                NgayTraPhong = c.NgayTraPhong,
                PhuongThucThanhToan = c.PhuongThucThanhToan,
                SoLuongNguoi = c.SoLuongNguoi,
                ThanhTien = c.ThanhTien,
                
            }).ToListAsync();
        }

        public async Task<ChiTietDatPhongVM?> GetByIdAsync(int id)
        {
            var entity = await _context.ChiTietDatPhongs.FindAsync(id);
            if (entity == null) return null;

            return new ChiTietDatPhongVM
            {
                IdChiTietDatPhong = entity.IdChiTietDatPhong,
                IdPhong = entity.IdPhong,
                IdDatPhong = entity.IdDatPhong,                
                IdKhachHang = entity.IdKhachHang,
                NgayDatPhong = entity.NgayDatPhong,
                NgayTraPhong = entity.NgayTraPhong,
                PhuongThucThanhToan = entity.PhuongThucThanhToan,
                SoLuongNguoi = entity.SoLuongNguoi,
                ThanhTien = entity.ThanhTien
            };
        }

        public async Task<ChiTietDatPhongVM> AddAsync(AddChiTietDatPhong model)
        {
            var entity = new ChiTietDatPhong
            {
                IdDatPhong = model.IdDatPhong,
                IdPhong = model.IdPhong,
                IdKhachHang = model.IdKhachHang,
                NgayDatPhong = model.NgayDatPhong,
                NgayTraPhong = model.NgayTraPhong,
                PhuongThucThanhToan = model.PhuongThucThanhToan,
                SoLuongNguoi = model.SoLuongNguoi,
                ThanhTien = model.ThanhTien
            };

            _context.ChiTietDatPhongs.Add(entity);
            await _context.SaveChangesAsync();

            return new ChiTietDatPhongVM
            {
                IdChiTietDatPhong = entity.IdChiTietDatPhong,
                IdDatPhong = entity.IdDatPhong,
                IdPhong = entity.IdPhong,
                IdKhachHang = entity.IdKhachHang,
                NgayDatPhong = entity.NgayDatPhong,
                NgayTraPhong = entity.NgayTraPhong,
                PhuongThucThanhToan = entity.PhuongThucThanhToan,
                SoLuongNguoi = entity.SoLuongNguoi,
                ThanhTien = entity.ThanhTien
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateChiTietDatPhong model)
        {
            var entity = await _context.ChiTietDatPhongs.FindAsync(id);
            if (entity == null) return false;

            entity.IdDatPhong = model.IdDatPhong;
            entity.IdPhong = model.IdPhong;
            entity.IdKhachHang = model.IdKhachHang;
            entity.NgayDatPhong = model.NgayDatPhong;
            entity.NgayTraPhong = model.NgayTraPhong;
            entity.PhuongThucThanhToan = model.PhuongThucThanhToan;
            entity.SoLuongNguoi = model.SoLuongNguoi;
            entity.ThanhTien = model.ThanhTien;

            _context.ChiTietDatPhongs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ChiTietDatPhongs.FindAsync(id);
            if (entity == null) return false;

            _context.ChiTietDatPhongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}