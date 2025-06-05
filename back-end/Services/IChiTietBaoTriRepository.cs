using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IChiTietBaoTriRepository
    {
        Task<IEnumerable<ChiTietBaoTri>> GetAllAsync();
        Task<ChiTietBaoTri?> GetByIdAsync(int id);
        Task<ChiTietBaoTri> AddAsync(ChiTietBaoTri entity);
        Task<bool> UpdateAsync(ChiTietBaoTri entity);
        Task<bool> DeleteAsync(int id);
    }
    public class ChiTietBaoTriRepository : IChiTietBaoTriRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietBaoTriRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietBaoTri>> GetAllAsync()
        {
            return await _context.ChiTietBaoTris.ToListAsync();
        }

        public async Task<ChiTietBaoTri?> GetByIdAsync(int id)
        {
            return await _context.ChiTietBaoTris.FindAsync(id);
        }

        public async Task<ChiTietBaoTri> AddAsync(ChiTietBaoTri entity)
        {
            _context.ChiTietBaoTris.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(ChiTietBaoTri entity)
        {
            _context.ChiTietBaoTris.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.ChiTietBaoTris.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}