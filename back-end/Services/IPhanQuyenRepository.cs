using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IPhanQuyenRepository
    {
        Task<IEnumerable<PhanQuyenVM>> GetAllAsync();
        Task<PhanQuyenVM?> GetByIdAsync(int id);
        Task<PhanQuyenVM> AddAsync(AddPhanQuyen model);
        Task<bool> UpdateAsync(int id, UpdatePhanQuyen model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PhanQuyen>> GetPhanQuyenByVaiTroIdAsync(int idVaiTro);
    }

    public class PhanQuyenRepository : IPhanQuyenRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhanQuyenRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhanQuyenVM>> GetAllAsync()
        {
            var phanQuyens = await _context.PhanQuyens
                .Include(p => p.IdVaiTroNavigation)
                .Select(p => new PhanQuyenVM
                {
                    IdPhanQuyen = p.IdPhanQuyen,
                    TenQuyen = p.TenQuyen,
                    IdVaiTro = p.IdVaiTro,
                    QuyenHan = p.QuyenHan,
                    TenVaiTro = p.IdVaiTroNavigation.TenVaiTro
                })
                .ToListAsync();
            return phanQuyens;
        }

        public async Task<PhanQuyenVM?> GetByIdAsync(int id)
        {
            var phanQuyen = await _context.PhanQuyens
                .Include(p => p.IdVaiTroNavigation)
                .Where(p => p.IdPhanQuyen == id)
                .Select(p => new PhanQuyenVM
                {
                    IdPhanQuyen = p.IdPhanQuyen,
                    TenQuyen = p.TenQuyen,
                    IdVaiTro = p.IdVaiTro,
                    QuyenHan = p.QuyenHan,
                    TenVaiTro = p.IdVaiTroNavigation.TenVaiTro
                })
                .FirstOrDefaultAsync();
            return phanQuyen;
        }

        public async Task<PhanQuyenVM> AddAsync(AddPhanQuyen model)
        {
            var phanQuyen = new PhanQuyen
            {
                TenQuyen = model.TenQuyen,
                IdVaiTro = model.IdVaiTro,
                QuyenHan = model.QuyenHan
            };

            _context.PhanQuyens.Add(phanQuyen);
            await _context.SaveChangesAsync();

            return new PhanQuyenVM
            {
                IdPhanQuyen = phanQuyen.IdPhanQuyen,
                TenQuyen = phanQuyen.TenQuyen,
                IdVaiTro = phanQuyen.IdVaiTro,
                QuyenHan = phanQuyen.QuyenHan
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhanQuyen model)
        {
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen == null) return false;

            phanQuyen.TenQuyen = model.TenQuyen;
            phanQuyen.IdVaiTro = model.IdVaiTro;
            phanQuyen.QuyenHan = model.QuyenHan;

            _context.PhanQuyens.Update(phanQuyen);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PhanQuyens.FindAsync(id);
            if (entity == null) return false;

            _context.PhanQuyens.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PhanQuyen>> GetPhanQuyenByVaiTroIdAsync(int idVaiTro)
        {
            return await _context.PhanQuyens
                .Where(p => p.IdVaiTro == idVaiTro)
                .ToListAsync();
        }
    }
}
