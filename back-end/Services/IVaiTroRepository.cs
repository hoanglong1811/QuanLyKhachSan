using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IVaiTroRepository
    {
        Task<IEnumerable<VaiTro>> GetAllAsync();
        Task<VaiTro?> GetByIdAsync(int id);
        Task<VaiTro> AddAsync(VaiTro vaiTro);
        Task<bool> UpdateAsync(VaiTro vaiTro);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }

    public class VaiTroRepository : IVaiTroRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public VaiTroRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaiTro>> GetAllAsync()
        {
            return await _context.VaiTros
                .Include(v => v.PhanQuyens)
                .Include(v => v.TaiKhoans)
                .ToListAsync();
        }

        public async Task<VaiTro?> GetByIdAsync(int id)
        {
            return await _context.VaiTros
                .Include(v => v.PhanQuyens)
                .Include(v => v.TaiKhoans)
                .FirstOrDefaultAsync(v => v.IdVaiTro == id);
        }

        public async Task<VaiTro> AddAsync(VaiTro vaiTro)
        {
            _context.VaiTros.Add(vaiTro);
            await _context.SaveChangesAsync();
            return vaiTro;
        }

        public async Task<bool> UpdateAsync(VaiTro vaiTro)
        {
            _context.Entry(vaiTro).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(vaiTro.IdVaiTro))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vaiTro = await _context.VaiTros.FindAsync(id);
            if (vaiTro == null)
            {
                return false;
            }

            _context.VaiTros.Remove(vaiTro);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.VaiTros.AnyAsync(e => e.IdVaiTro == id);
        }
    }
}
