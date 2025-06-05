using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IKhachHangRepository
    {
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang?> GetByIdAsync(int id);
        Task<KhachHang> AddAsync(KhachHang entity);
        Task<bool> UpdateAsync(KhachHang entity);
        Task<bool> DeleteAsync(int id);
    }

    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public KhachHangRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KhachHang>> GetAllAsync()
        {
            return await _context.KhachHangs.ToListAsync();
        }

        public async Task<KhachHang?> GetByIdAsync(int id)
        {
            return await _context.KhachHangs.FindAsync(id);
        }

        public async Task<KhachHang> AddAsync(KhachHang entity)
        {
            _context.KhachHangs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(KhachHang entity)
        {
            _context.KhachHangs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.KhachHangs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
