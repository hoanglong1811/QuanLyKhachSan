using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface ITaiKhoanRepository
    {
        Task<IEnumerable<TaiKhoan>> GetAllAsync();
        Task<TaiKhoan?> GetByIdAsync(int id);
        Task<TaiKhoan?> GetByUsernameAsync(string username);
        Task<TaiKhoan?> GetByEmailAsync(string email);
        Task<TaiKhoan> AddAsync(TaiKhoan taiKhoan);
        Task<bool> UpdateAsync(TaiKhoan taiKhoan);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsUsernameUniqueAsync(string username, int? excludeId = null);
        Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null);
    }

    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public TaiKhoanRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaiKhoan>> GetAllAsync()
        {
            return await _context.TaiKhoans
                .Include(tk => tk.IdVaiTroNavigation)
                .Include(tk => tk.NhanViens)
                .ToListAsync();
        }

        public async Task<TaiKhoan?> GetByIdAsync(int id)
        {
            return await _context.TaiKhoans
                .Include(tk => tk.IdVaiTroNavigation)
                .Include(tk => tk.NhanViens)
                .FirstOrDefaultAsync(tk => tk.IdTaiKhoan == id);
        }

        public async Task<TaiKhoan?> GetByUsernameAsync(string username)
        {
            return await _context.TaiKhoans
                .Include(tk => tk.IdVaiTroNavigation)
                .Include(tk => tk.NhanViens)
                .FirstOrDefaultAsync(tk => tk.TenDangNhap == username);
        }

        public async Task<TaiKhoan?> GetByEmailAsync(string email)
        {
            return await _context.TaiKhoans
                .Include(tk => tk.IdVaiTroNavigation)
                .Include(tk => tk.NhanViens)
                .FirstOrDefaultAsync(tk => tk.Email == email);
        }

        public async Task<TaiKhoan> AddAsync(TaiKhoan taiKhoan)
        {
            _context.TaiKhoans.Add(taiKhoan);
            await _context.SaveChangesAsync();
            return taiKhoan;
        }

        public async Task<bool> UpdateAsync(TaiKhoan taiKhoan)
        {
            _context.Entry(taiKhoan).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(taiKhoan.IdTaiKhoan))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return false;
            }

            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.TaiKhoans.AnyAsync(e => e.IdTaiKhoan == id);
        }

        public async Task<bool> IsUsernameUniqueAsync(string username, int? excludeId = null)
        {
            return !await _context.TaiKhoans
                .AnyAsync(tk => tk.TenDangNhap == username && 
                               (!excludeId.HasValue || tk.IdTaiKhoan != excludeId.Value));
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null)
        {
            return !await _context.TaiKhoans
                .AnyAsync(tk => tk.Email == email && 
                               (!excludeId.HasValue || tk.IdTaiKhoan != excludeId.Value));
        }
    }
}