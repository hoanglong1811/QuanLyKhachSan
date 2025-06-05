using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface ILoaiPhongRepository
    {
        Task<IEnumerable<LoaiPhong>> GetAllAsync();
        Task<LoaiPhong?> GetByIdAsync(int id);
        Task<LoaiPhong> AddAsync(LoaiPhong entity);
        Task<bool> UpdateAsync(LoaiPhong entity);
        Task<bool> DeleteAsync(int id);
    }

    public class LoaiPhongRepository : ILoaiPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public LoaiPhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoaiPhong>> GetAllAsync()
        {
            return await _context.LoaiPhongs.ToListAsync();
        }

        public async Task<LoaiPhong?> GetByIdAsync(int id)
        {
            return await _context.LoaiPhongs.FindAsync(id);
        }

        public async Task<LoaiPhong> AddAsync(LoaiPhong entity)
        {
            _context.LoaiPhongs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(LoaiPhong entity)
        {
            _context.LoaiPhongs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.LoaiPhongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
