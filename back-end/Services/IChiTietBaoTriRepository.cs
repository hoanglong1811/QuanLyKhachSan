using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IChiTietBaoTriRepository
    {
        Task<IEnumerable<ChiTietBaoTriVM>> GetAllAsync();
        Task<ChiTietBaoTriVM?> GetByIdAsync(int id);
        Task AddAsync(AddChiTietBaoTri model);
        Task UpdateAsync(UpdateChiTietBaoTri model);
        Task<bool> DeleteAsync(int id);
    }
    public class ChiTietBaoTriRepository : IChiTietBaoTriRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietBaoTriRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietBaoTriVM>> GetAllAsync()
        {
            return await _context.ChiTietBaoTris
                .Select(ct => new ChiTietBaoTriVM
                {
                    IdChiTietBaoTri = ct.IdChiTietBaoTri,
                    IdThietBi = ct.IdThietBi,
                    NgayBatDau = ct.NgayBatDau,
                    NgayKetThuc = ct.NgayKetThuc,
                    SoLuongThietBi = ct.SoLuongThietBi,
                    IdPhieuBaoTri = ct.IdPhieuBaoTri
                })
                .ToListAsync();
        }

        public async Task<ChiTietBaoTriVM?> GetByIdAsync(int id)
        {
            return await _context.ChiTietBaoTris
                .Where(ct => ct.IdChiTietBaoTri == id)
                .Select(ct => new ChiTietBaoTriVM
                {
                    IdChiTietBaoTri = ct.IdChiTietBaoTri,
                    IdThietBi = ct.IdThietBi,
                    NgayBatDau = ct.NgayBatDau,
                    NgayKetThuc = ct.NgayKetThuc,
                    SoLuongThietBi = ct.SoLuongThietBi,
                    IdPhieuBaoTri = ct.IdPhieuBaoTri
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(AddChiTietBaoTri model)
        {
            var entity = new ChiTietBaoTri
            {
                IdThietBi = model.IdThietBi,
                NgayBatDau = model.NgayBatDau,
                NgayKetThuc = model.NgayKetThuc,
                SoLuongThietBi = model.SoLuongThietBi,
                IdPhieuBaoTri = model.IdPhieuBaoTri
            };
            _context.ChiTietBaoTris.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateChiTietBaoTri model)
        {
            var entity = await _context.ChiTietBaoTris.FindAsync(model.IdChiTietBaoTri);
            if (entity != null)
            {
                entity.IdThietBi = model.IdThietBi;
                entity.NgayBatDau = model.NgayBatDau;
                entity.NgayKetThuc = model.NgayKetThuc;
                entity.SoLuongThietBi = model.SoLuongThietBi;
                entity.IdPhieuBaoTri = model.IdPhieuBaoTri;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ChiTietBaoTris.FindAsync(id);
            if (entity == null) return false;

            _context.ChiTietBaoTris.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}