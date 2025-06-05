using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IPhanQuyenRepository
    {
        Task<IEnumerable<PhanQuyen>> GetAllAsync();
        Task<PhanQuyen?> GetByIdAsync(int id);
        Task<PhanQuyen> AddAsync(PhanQuyen entity);
        Task<bool> UpdateAsync(PhanQuyen entity);
        Task<bool> DeleteAsync(int id);
    }

    public class PhanQuyenRepository : IPhanQuyenRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhanQuyenRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhanQuyen>> GetAllAsync()
        {
            return await _context.PhanQuyens.ToListAsync();
        }

        public async Task<PhanQuyen?> GetByIdAsync(int id)
        {
            return await _context.PhanQuyens.FindAsync(id);
        }

        public async Task<PhanQuyen> AddAsync(PhanQuyen entity)
        {
            _context.PhanQuyens.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(PhanQuyen entity)
        {
            _context.PhanQuyens.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.PhanQuyens.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
