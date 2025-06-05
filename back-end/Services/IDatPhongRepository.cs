using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IDatPhongRepository
    {
        Task<IEnumerable<DatPhong>> GetAllAsync();
        Task<DatPhong?> GetByIdAsync(int id);
        Task<DatPhong> AddAsync(DatPhong entity);
        Task<bool> UpdateAsync(DatPhong entity);
        Task<bool> DeleteAsync(int id);
    }

    public class DatPhongRepository : IDatPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public DatPhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DatPhong>> GetAllAsync()
        {
            return await _context.DatPhongs.ToListAsync();
        }

        public async Task<DatPhong?> GetByIdAsync(int id)
        {
            return await _context.DatPhongs.FindAsync(id);
        }

        public async Task<DatPhong> AddAsync(DatPhong entity)
        {
            _context.DatPhongs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(DatPhong entity)
        {
            _context.DatPhongs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.DatPhongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
