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
        Task<TaiKhoan> AddAsync(TaiKhoan taiKhoan);
        Task<bool> UpdateAsync(TaiKhoan taiKhoan);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsUsernameUniqueAsync(string username, int? excludeId = null);
        Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null);
        Task<TaiKhoan> GetByUsernameAndPasswordAsync(string username, string hashedPassword);
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
                .ToListAsync();
        }

        public async Task<TaiKhoan?> GetByIdAsync(int id)
        {
            var taiKhoan = await _context.TaiKhoans
                .Include(tk => tk.IdVaiTroNavigation)
                .FirstOrDefaultAsync(tk => tk.IdTaiKhoan == id);

            return taiKhoan;
        }

        public async Task<TaiKhoan> AddAsync(TaiKhoan taiKhoan)
        {
            await _context.TaiKhoans.AddAsync(taiKhoan);
            await _context.SaveChangesAsync();
            return taiKhoan;
        }

        public async Task<bool> UpdateAsync(TaiKhoan taiKhoan)
        {
            var existingTaiKhoan = await _context.TaiKhoans.FindAsync(taiKhoan.IdTaiKhoan);
            if (existingTaiKhoan == null)
                return false;

            _context.Entry(existingTaiKhoan).CurrentValues.SetValues(taiKhoan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
                return false;

            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsUsernameUniqueAsync(string username, int? excludeId = null)
        {
            return !await _context.TaiKhoans.AnyAsync(tk =>
                tk.TenDangNhap == username &&
                (!excludeId.HasValue || tk.IdTaiKhoan != excludeId.Value));
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null)
        {
            return !await _context.TaiKhoans.AnyAsync(tk =>
                tk.Email == email &&
                (!excludeId.HasValue || tk.IdTaiKhoan != excludeId.Value));
        }

        public async Task<TaiKhoan> GetByUsernameAndPasswordAsync(string username, string hashedPassword)
        {
            return await _context.TaiKhoans
                .Include(tk => tk.IdVaiTroNavigation)
                .FirstOrDefaultAsync(tk => tk.TenDangNhap == username && tk.MatKhau == hashedPassword);
        }
    }
}