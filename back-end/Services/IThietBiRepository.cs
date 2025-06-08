using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IThietBiRepository
    {
        Task<IEnumerable<ThietBi>> GetAllAsync();
        Task<IEnumerable<ThietBiVM>> GetAllWithDetailsAsync();
        Task<ThietBi?> GetByIdAsync(int id);
        Task<ThietBiVM?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<ThietBiVM>> GetByPhongIdAsync(int phongId);
        Task<ThietBi> AddAsync(ThietBi entity);
        Task<bool> UpdateAsync(ThietBi entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<ThietBi>> GetThietBiCanBaoTriAsync();
        Task<int> CountThietBiByPhongAsync(int phongId);
    }

    public class ThietBiRepository : IThietBiRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ThietBiRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ThietBi>> GetAllAsync()
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<ThietBiVM>> GetAllWithDetailsAsync()
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .Select(tb => new ThietBiVM
                {
                    IdThietBi = tb.IdThietBi,
                    TenThietBi = tb.TenThietBi,
                    LoaiThietBi = tb.LoaiThietBi,
                    TinhTrang = tb.TinhTrang,
                    Gia = tb.Gia,
                    SoLuong = tb.SoLuong,
                    IdPhong = tb.IdPhong,
                    SoPhong = tb.IdPhongNavigation.SoPhong.ToString()
                })
                .ToListAsync();
        }

        public async Task<ThietBi?> GetByIdAsync(int id)
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .FirstOrDefaultAsync(tb => tb.IdThietBi == id);
        }

        public async Task<ThietBiVM?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .Where(tb => tb.IdThietBi == id)
                .Select(tb => new ThietBiVM
                {
                    IdThietBi = tb.IdThietBi,
                    TenThietBi = tb.TenThietBi,
                    LoaiThietBi = tb.LoaiThietBi,
                    TinhTrang = tb.TinhTrang,
                    Gia = tb.Gia,
                    SoLuong = tb.SoLuong,
                    IdPhong = tb.IdPhong,
                    SoPhong = tb.IdPhongNavigation.SoPhong.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ThietBiVM>> GetByPhongIdAsync(int phongId)
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .Where(tb => tb.IdPhong == phongId)
                .Select(tb => new ThietBiVM
                {
                    IdThietBi = tb.IdThietBi,
                    TenThietBi = tb.TenThietBi,
                    LoaiThietBi = tb.LoaiThietBi,
                    TinhTrang = tb.TinhTrang,
                    Gia = tb.Gia,
                    SoLuong = tb.SoLuong,
                    IdPhong = tb.IdPhong,
                    SoPhong = tb.IdPhongNavigation.SoPhong.ToString()
                })
                .ToListAsync();
        }

        public async Task<ThietBi> AddAsync(ThietBi entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.ThietBis.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(ThietBi entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingEntity = await _context.ThietBis.FindAsync(entity.IdThietBi);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ThietBis.FindAsync(id);
            if (entity == null)
                return false;

            _context.ThietBis.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ThietBis.AnyAsync(e => e.IdThietBi == id);
        }

        public async Task<IEnumerable<ThietBi>> GetThietBiCanBaoTriAsync()
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .Where(tb => tb.TinhTrang == "Cần bảo trì" || tb.TinhTrang == "Hỏng")
                .ToListAsync();
        }

        public async Task<int> CountThietBiByPhongAsync(int phongId)
        {
            return await _context.ThietBis
                .Where(tb => tb.IdPhong == phongId)
                .CountAsync();
        }
    }
}
