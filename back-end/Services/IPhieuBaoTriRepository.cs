using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IPhieuBaoTriRepository
    {
        Task<IEnumerable<PhieuBaoTriVM>> GetAllAsync();
        Task<PhieuBaoTriVM?> GetByIdAsync(int id);
        Task<PhieuBaoTriVM> AddAsync(AddPhieuBaoTri model);
        Task<bool> UpdateAsync(int id, UpdatePhieuBaoTri model);
        Task<bool> DeleteAsync(int id);
    }

    public class PhieuBaoTriRepository : IPhieuBaoTriRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhieuBaoTriRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhieuBaoTriVM>> GetAllAsync()
        {
            return await _context.PhieuBaoTris
                .Include(p => p.ChiTietBaoTris)
                .Select(p => new PhieuBaoTriVM
                {
                    IdPhieuBaoTri = p.IdPhieuBaoTri,
                    MoTaVanDe = p.MoTaVanDe,
                    NgayTao = p.NgayTao,
                    TrangThai = p.TrangThai,
                    IdNhanVien = p.IdNhanVien
                }).ToListAsync();
        }

        public async Task<PhieuBaoTriVM?> GetByIdAsync(int id)
        {
            return await _context.PhieuBaoTris
                .Include(p => p.ChiTietBaoTris)
                .Select(p => new PhieuBaoTriVM
                {
                    IdPhieuBaoTri = p.IdPhieuBaoTri,
                    MoTaVanDe = p.MoTaVanDe,
                    NgayTao = p.NgayTao,
                    TrangThai = p.TrangThai,
                    IdNhanVien = p.IdNhanVien
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PhieuBaoTriVM> AddAsync(AddPhieuBaoTri model)
        {
            var phieu = new PhieuBaoTri
            {
                MoTaVanDe = model.MoTaVanDe,
                NgayTao = model.NgayTao ?? DateTime.Now,
                TrangThai = model.TrangThai,
                IdNhanVien = model.IdNhanVien
            };
            _context.PhieuBaoTris.Add(phieu);
            await _context.SaveChangesAsync();           

            return await GetByIdAsync(phieu.IdPhieuBaoTri) ?? new PhieuBaoTriVM();
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhieuBaoTri model)
        {
            var phieu = await _context.PhieuBaoTris.FirstOrDefaultAsync(p => p.IdPhieuBaoTri == id);
            if (phieu == null) return false;

            phieu.MoTaVanDe = model.MoTaVanDe;
            phieu.NgayTao = model.NgayTao;
            phieu.TrangThai = model.TrangThai;
            phieu.IdNhanVien = model.IdNhanVien;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var phieu = await _context.PhieuBaoTris.FindAsync(id);
            if (phieu == null) return false;

            _context.PhieuBaoTris.Remove(phieu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
