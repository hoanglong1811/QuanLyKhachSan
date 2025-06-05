using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IHoaDonRepository
    {
        Task<IEnumerable<HoaDon>> GetAllAsync();
        Task<HoaDon?> GetByIdAsync(int id);
        Task<HoaDon> AddAsync(HoaDon entity);
        Task<bool> UpdateAsync(HoaDon entity);
        Task<bool> DeleteAsync(int id);
    }

    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public HoaDonRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HoaDon>> GetAllAsync()
        {
            return await _context.HoaDons.ToListAsync();
        }

        public async Task<HoaDon?> GetByIdAsync(int id)
        {
            return await _context.HoaDons.FindAsync(id);
        }

        public async Task<HoaDon> AddAsync(HoaDon entity)
        {
            _context.HoaDons.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(HoaDon entity)
        {
            _context.HoaDons.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.HoaDons.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
