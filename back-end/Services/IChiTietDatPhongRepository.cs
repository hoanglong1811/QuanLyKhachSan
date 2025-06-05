using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IChiTietDatPhongRepository
    {
        Task<IEnumerable<ChiTietDatPhong>> GetAllAsync();
        Task<ChiTietDatPhong?> GetByIdAsync(int id);
        Task<ChiTietDatPhong> AddAsync(ChiTietDatPhong entity);
        Task<bool> UpdateAsync(ChiTietDatPhong entity);
        Task<bool> DeleteAsync(int id);
    }

    public class ChiTietDatPhongRepository : IChiTietDatPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietDatPhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietDatPhong>> GetAllAsync()
        {
            return await _context.ChiTietDatPhongs.ToListAsync();
        }

        public async Task<ChiTietDatPhong?> GetByIdAsync(int id)
        {
            return await _context.ChiTietDatPhongs.FindAsync(id);
        }

        public async Task<ChiTietDatPhong> AddAsync(ChiTietDatPhong entity)
        {
            _context.ChiTietDatPhongs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(ChiTietDatPhong entity)
        {
            _context.ChiTietDatPhongs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.ChiTietDatPhongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}