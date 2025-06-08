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
                .Include(p => p.IdNhanVienNavigation)
                .Select(p => new PhieuBaoTriVM
                {
                    Id = p.IdPhieuBaoTri,
                    ThietBiId = p.ChiTietBaoTris.FirstOrDefault().IdThietBi,
                    NgayBaoTri = p.NgayTao ?? System.DateTime.MinValue,
                    MoTa = p.MoTaVanDe,
                    TrangThai = p.TrangThai == "Đã hoàn thành",
                    TenNhanVien = p.IdNhanVienNavigation.HoTen,
                    TenThietBi = p.ChiTietBaoTris.FirstOrDefault().IdThietBiNavigation.TenThietBi,
                    SoPhong = p.ChiTietBaoTris.FirstOrDefault().IdThietBiNavigation.IdPhongNavigation.SoPhong.ToString()
                })
                .ToListAsync();
        }

        public async Task<PhieuBaoTriVM?> GetByIdAsync(int id)
        {
            return await _context.PhieuBaoTris
                .Include(p => p.ChiTietBaoTris)
                .Include(p => p.IdNhanVienNavigation)
                .Where(p => p.IdPhieuBaoTri == id)
                .Select(p => new PhieuBaoTriVM
                {
                    Id = p.IdPhieuBaoTri,
                    ThietBiId = p.ChiTietBaoTris.FirstOrDefault().IdThietBi,
                    NgayBaoTri = p.NgayTao ?? System.DateTime.MinValue,
                    MoTa = p.MoTaVanDe,
                    TrangThai = p.TrangThai == "Đã hoàn thành",
                    TenNhanVien = p.IdNhanVienNavigation.HoTen,
                    TenThietBi = p.ChiTietBaoTris.FirstOrDefault().IdThietBiNavigation.TenThietBi,
                    SoPhong = p.ChiTietBaoTris.FirstOrDefault().IdThietBiNavigation.IdPhongNavigation.SoPhong.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PhieuBaoTriVM> AddAsync(AddPhieuBaoTri model)
        {
            var phieu = new PhieuBaoTri
            {
                MoTaVanDe = model.MoTa,
                NgayTao = model.NgayBaoTri,
                TrangThai = model.TrangThai == true ? "Đã hoàn thành" : "Chưa hoàn thành",
                IdNhanVien = 1 // Cần sửa lại để lấy từ user đăng nhập
            };
            _context.PhieuBaoTris.Add(phieu);
            await _context.SaveChangesAsync();

            var chiTiet = new ChiTietBaoTri
            {
                IdPhieuBaoTri = phieu.IdPhieuBaoTri,
                IdThietBi = model.ThietBiId,
                NgayBatDau = model.NgayBaoTri,
                NgayKetThuc = null
            };
            _context.ChiTietBaoTris.Add(chiTiet);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(phieu.IdPhieuBaoTri) ?? new PhieuBaoTriVM();
        }

        public async Task<bool> UpdateAsync(int id, UpdatePhieuBaoTri model)
        {
            var phieu = await _context.PhieuBaoTris.Include(p => p.ChiTietBaoTris).FirstOrDefaultAsync(p => p.IdPhieuBaoTri == id);
            if (phieu == null) return false;
            phieu.MoTaVanDe = model.MoTa;
            phieu.NgayTao = model.NgayBaoTri;
            phieu.TrangThai = model.TrangThai == true ? "Đã hoàn thành" : "Chưa hoàn thành";
            // Cập nhật chi tiết bảo trì
            var chiTiet = phieu.ChiTietBaoTris.FirstOrDefault();
            if (chiTiet != null)
            {
                chiTiet.IdThietBi = model.ThietBiId;
                chiTiet.NgayBatDau = model.NgayBaoTri;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var phieu = await _context.PhieuBaoTris.Include(p => p.ChiTietBaoTris).FirstOrDefaultAsync(p => p.IdPhieuBaoTri == id);
            if (phieu == null) return false;
            _context.ChiTietBaoTris.RemoveRange(phieu.ChiTietBaoTris);
            _context.PhieuBaoTris.Remove(phieu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
