using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IChiTietHoaDonRepository
    {
        Task<IEnumerable<ChiTietHoaDonVM>> GetAllAsync();
        Task<ChiTietHoaDonVM?> GetByIdAsync(int id);
        Task AddAsync(AddChiTietHoaDon model);
        Task UpdateAsync(UpdateChiTietHoaDon model);
        Task DeleteAsync(int id);
    }
    public class ChiTietHoaDonRepository : IChiTietHoaDonRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietHoaDonRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietHoaDonVM>> GetAllAsync()
        {
            return await _context.ChiTietHoaDons
                .Select(cthd => new ChiTietHoaDonVM
                {
                    IdChiTietHoaDon = cthd.IdChiTietHoaDon,
                    IdHoaDon = cthd.IdHoaDon,
                    IdDatPhong = cthd.IdDatPhong,
                    IdChiTietDichVu = cthd.IdChiTietDichVu,
                    MoTa = cthd.MoTa,
                    ThanhTien = cthd.ThanhTien,
                    NgayTao = cthd.NgayTao,
                    GhiChu = cthd.GhiChu
                })
                .ToListAsync();
        }

        public async Task<ChiTietHoaDonVM?> GetByIdAsync(int id)
        {
            return await _context.ChiTietHoaDons
                .Where(cthd => cthd.IdChiTietHoaDon == id)
                .Select(cthd => new ChiTietHoaDonVM
                {
                    IdChiTietHoaDon = cthd.IdChiTietHoaDon,
                    IdHoaDon = cthd.IdHoaDon,
                    IdDatPhong = cthd.IdDatPhong,
                    IdChiTietDichVu = cthd.IdChiTietDichVu,
                    MoTa = cthd.MoTa,
                    ThanhTien = cthd.ThanhTien,
                    NgayTao = cthd.NgayTao,
                    GhiChu = cthd.GhiChu
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(AddChiTietHoaDon model)
        {
            var entity = new ChiTietHoaDon
            {
                IdHoaDon = model.IdHoaDon,
                IdDatPhong = model.IdDatPhong,
                IdChiTietDichVu = model.IdChiTietDichVu,
                MoTa = model.MoTa,
                ThanhTien = model.ThanhTien,
                NgayTao = model.NgayTao ?? DateTime.Now,
                GhiChu = model.GhiChu
            };
            _context.ChiTietHoaDons.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateChiTietHoaDon model)
        {
            var entity = await _context.ChiTietHoaDons.FindAsync(model.IdChiTietHoaDon);
            if (entity != null)
            {
                entity.IdHoaDon = model.IdHoaDon;
                entity.IdDatPhong = model.IdDatPhong;
                entity.IdChiTietDichVu = model.IdChiTietDichVu;
                entity.MoTa = model.MoTa;
                entity.ThanhTien = model.ThanhTien;
                entity.NgayTao = model.NgayTao;
                entity.GhiChu = model.GhiChu;

                await _context.SaveChangesAsync();
            }
        }
    

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ChiTietHoaDons.FindAsync(id);
            if (entity != null)
            {
                _context.ChiTietHoaDons.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}