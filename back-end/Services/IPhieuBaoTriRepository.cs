using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IPhieuBaoTriRepository
    {
        Task<IEnumerable<PhieuBaoTri>> GetAllAsync();
        Task<PhieuBaoTri?> GetByIdAsync(int id);
        Task<PhieuBaoTri> AddAsync(PhieuBaoTri entity);
        Task<bool> UpdateAsync(PhieuBaoTri entity);
        Task<bool> DeleteAsync(int id);
    }

    public class PhieuBaoTriRepository : IPhieuBaoTriRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhieuBaoTriRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhieuBaoTri>> GetAllAsync()
        {
            return await _context.PhieuBaoTris.ToListAsync();
        }

        public async Task<PhieuBaoTri?> GetByIdAsync(int id)
        {
            return await _context.PhieuBaoTris.FindAsync(id);
        }

        public async Task<PhieuBaoTri> AddAsync(PhieuBaoTri entity)
        {
            _context.PhieuBaoTris.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(PhieuBaoTri entity)
        {
            _context.PhieuBaoTris.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.PhieuBaoTris.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
//     Task<IEnumerable<PhieuBaoTri>> GetAllAsync();