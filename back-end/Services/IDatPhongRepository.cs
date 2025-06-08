using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using back_end.ViewModels;
namespace back_end.Services
{
    public interface IDatPhongRepository
    {
        Task<IEnumerable<DatPhongVM>> GetAllAsync();
        Task<DatPhongVM?> GetByIdAsync(int id);
        Task<DatPhongVM> AddAsync(AddDatPhong entity);
        Task<bool> UpdateAsync(int id, UpdateDatPhong entity);
        Task<bool> DeleteAsync(int id);
    }

    public class DatPhongRepository : IDatPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public DatPhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DatPhongVM>> GetAllAsync()
        {
            return await _context.DatPhongs
                .Select(dp => new DatPhongVM
                {
                    IdDatPhong = dp.IdDatPhong,
                    NgayDatPhong = dp.NgayDatPhong,
                    NgayTraPhong = dp.NgayTraPhong,
                    TrangThaiDatPhong = dp.TrangThaiDatPhong,
                    GhiChu = dp.GhiChu,
                    IdKhachHang = dp.IdKhachHang
                })
                .ToListAsync();
        }

        public async Task<DatPhongVM?> GetByIdAsync(int id)
        {
            return await _context.DatPhongs
                .Where(dp => dp.IdDatPhong == id)
                .Select(dp => new DatPhongVM
                {
                    IdDatPhong = dp.IdDatPhong,
                    NgayDatPhong = dp.NgayDatPhong,
                    NgayTraPhong = dp.NgayTraPhong,
                    TrangThaiDatPhong = dp.TrangThaiDatPhong,
                    GhiChu = dp.GhiChu,
                    IdKhachHang = dp.IdKhachHang
                })
                .FirstOrDefaultAsync();
        }

        public async Task<DatPhongVM> AddAsync(AddDatPhong entity)
        {
            var datPhong = new DatPhong
            {
                NgayDatPhong = entity.NgayDatPhong,
                NgayTraPhong = entity.NgayTraPhong,
                TrangThaiDatPhong = entity.TrangThaiDatPhong,
                GhiChu = entity.GhiChu,
                IdKhachHang = entity.IdKhachHang
            };
            _context.DatPhongs.Add(datPhong);
            await _context.SaveChangesAsync();
            return new DatPhongVM
            {
                IdDatPhong = datPhong.IdDatPhong,
                NgayDatPhong = datPhong.NgayDatPhong,
                NgayTraPhong = datPhong.NgayTraPhong,
                TrangThaiDatPhong = datPhong.TrangThaiDatPhong,
                GhiChu = datPhong.GhiChu,
                IdKhachHang = datPhong.IdKhachHang
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateDatPhong entity)
        {
            var datPhong = await _context.DatPhongs.FindAsync(id);
            if (datPhong == null) return false;
            datPhong.NgayDatPhong = entity.NgayDatPhong;
            datPhong.NgayTraPhong = entity.NgayTraPhong;
            datPhong.TrangThaiDatPhong = entity.TrangThaiDatPhong;
            datPhong.GhiChu = entity.GhiChu;
            datPhong.IdKhachHang = entity.IdKhachHang;
            _context.DatPhongs.Update(datPhong);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DatPhongs.FindAsync(id);
            if (entity == null) return false;
            _context.DatPhongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
