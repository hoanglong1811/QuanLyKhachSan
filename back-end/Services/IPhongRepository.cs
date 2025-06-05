using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IPhongRepository
    {
        Task<IEnumerable<PhongVM>> GetAllAsync();
        Task<PhongVM?> GetByIdAsync(int id);
        Task<PhongVM> AddAsync(AddPhong model);
        Task<bool> UpdateAsync(int id, UpdatePhong model);
        Task<bool> DeleteAsync(int id);
    }

    public class PhongRepository : IPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhongVM>> GetAllAsync()
        {
            var phongs = await _context.Phongs
                .Include(p => p.IdLoaiPhongNavigation)
                .Select(p => new PhongVM
                {
                    IdPhong = p.IdPhong,
                    IdLoaiPhong = p.IdLoaiPhong,
                    SoPhong = p.SoPhong,
                    SucChua = p.SucChua,
                    TrangThai = p.TrangThai
                })
                .ToListAsync();
            return phongs;
        }

        public async Task<PhongVM?> GetByIdAsync(int id)
        {
            var phong = await _context.Phongs
                .Include(p => p.IdLoaiPhongNavigation)
                .Where(p => p.IdPhong == id)
                .Select(p => new PhongVM
                {
                    IdPhong = p.IdPhong,
                    IdLoaiPhong = p.IdLoaiPhong,
                    SoPhong = p.SoPhong,
                    SucChua = p.SucChua,
                    TrangThai = p.TrangThai
                })
                .FirstOrDefaultAsync();
            return phong;
        }

        public async Task<PhongVM> AddAsync(AddPhong model)
        {
            var phong = new Phong
            {
                IdLoaiPhong = model.IdLoaiPhong,
                SoPhong = model.SoPhong,
                SucChua = model.SucChua,
                TrangThai = model.TrangThai
            };

            _context.Phongs.Add(phong);
            await _context.SaveChangesAsync();

            return new PhongVM
            {
                IdPhong = phong.IdPhong,
                IdLoaiPhong = phong.IdLoaiPhong,
                SoPhong = phong.SoPhong,
                SucChua = phong.SucChua,
                TrangThai = phong.TrangThai
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhong model)
        {
            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null) return false;

            phong.IdLoaiPhong = model.IdLoaiPhong;
            phong.SoPhong = model.SoPhong;
            phong.SucChua = model.SucChua;
            phong.TrangThai = model.TrangThai;

            _context.Phongs.Update(phong);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Phongs.FindAsync(id);
            if (entity == null) return false;

            _context.Phongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
