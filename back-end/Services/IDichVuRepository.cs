using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace back_end.Services
{
    public interface IDichVuRepository
    {
        Task<IEnumerable<DichVu>> GetAllAsync();
        Task<DichVu?> GetByIdAsync(int id);
        Task<DichVu> AddAsync(DichVu entity);
        Task<bool> UpdateAsync(DichVu entity);
        Task<bool> DeleteAsync(int id);
    }

    public class DichVuRepository : IDichVuRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public DichVuRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DichVu>> GetAllAsync()
        {
            return await _context.DichVus.ToListAsync();
        }

        public async Task<DichVu?> GetByIdAsync(int id)
        {
            return await _context.DichVus.FindAsync(id);
        }

        public async Task<DichVu> AddAsync(DichVu entity)
        {
            _context.DichVus.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(DichVu entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.DichVus.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
