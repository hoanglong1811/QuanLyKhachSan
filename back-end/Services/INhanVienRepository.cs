using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface INhanVienRepository
    {
        Task<IEnumerable<NhanVien>> GetAllAsync();
        Task<NhanVien?> GetByIdAsync(int id);
        Task<NhanVien> AddAsync(NhanVien entity);
        Task<bool> UpdateAsync(NhanVien entity);
        Task<bool> DeleteAsync(int id);
    }

    public class NhanVienRepository : INhanVienRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public NhanVienRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NhanVien>> GetAllAsync()
        {
            return await _context.NhanViens.ToListAsync();
        }

        public async Task<NhanVien?> GetByIdAsync(int id)
        {
            return await _context.NhanViens.FindAsync(id);
        }

        public async Task<NhanVien> AddAsync(NhanVien entity)
        {
            _context.NhanViens.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(NhanVien entity)
        {
            _context.NhanViens.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.NhanViens.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
