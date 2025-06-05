using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IThietBiRepository
    {
        Task<IEnumerable<ThietBi>> GetAllAsync();
        Task<ThietBi?> GetByIdAsync(int id);
        Task<ThietBi> AddAsync(ThietBi entity);
        Task<bool> UpdateAsync(ThietBi entity);
        Task<bool> DeleteAsync(int id);
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
            return await _context.ThietBis.ToListAsync();
        }

        public async Task<ThietBi?> GetByIdAsync(int id)
        {
            return await _context.ThietBis.FindAsync(id);
        }

        public async Task<ThietBi> AddAsync(ThietBi entity)
        {
            _context.ThietBis.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(ThietBi entity)
        {
            _context.ThietBis.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.ThietBis.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
