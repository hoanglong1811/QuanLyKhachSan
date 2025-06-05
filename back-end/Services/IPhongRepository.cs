using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IPhongRepository
    {
        Task<IEnumerable<Phong>> GetAllAsync();
        Task<Phong?> GetByIdAsync(int id);
        Task<Phong> AddAsync(Phong entity);
        Task<bool> UpdateAsync(Phong entity);
        Task<bool> DeleteAsync(int id);
    }

    public class PhongRepository : IPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Phong>> GetAllAsync()
        {
            return await _context.Phongs.ToListAsync();
        }

        public async Task<Phong?> GetByIdAsync(int id)
        {
            return await _context.Phongs.FindAsync(id);
        }

        public async Task<Phong> AddAsync(Phong entity)
        {
            _context.Phongs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Phong entity)
        {
            _context.Phongs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.Phongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
