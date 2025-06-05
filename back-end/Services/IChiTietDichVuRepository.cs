using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace back_end.Services
{
    public interface IChiTietDichVuRepository
    {
        Task<IEnumerable<ChiTietDichVu>> GetAllAsync();
        Task<ChiTietDichVu?> GetByIdAsync(int id);
        Task<ChiTietDichVu> AddAsync(ChiTietDichVu entity);
        Task<bool> UpdateAsync(ChiTietDichVu entity);
        Task<bool> DeleteAsync(int id);
    }

    public class ChiTietDichVuRepository : IChiTietDichVuRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietDichVuRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietDichVu>> GetAllAsync()
        {
            return await _context.ChiTietDichVus.ToListAsync();
        }

        public async Task<ChiTietDichVu?> GetByIdAsync(int id)
        {
            return await _context.ChiTietDichVus.FindAsync(id);
        }

        public async Task<ChiTietDichVu> AddAsync(ChiTietDichVu entity)
        {
            _context.ChiTietDichVus.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(ChiTietDichVu entity)
        {
            _context.ChiTietDichVus.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.ChiTietDichVus.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
