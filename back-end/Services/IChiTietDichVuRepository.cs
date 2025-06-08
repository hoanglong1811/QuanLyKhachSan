using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.ViewModels;
namespace back_end.Services

{
    public interface IChiTietDichVuRepository
    {
        Task<IEnumerable<ChiTietDichVuVM>> GetAllAsync();
        Task<ChiTietDichVuVM?> GetByIdAsync(int id);
        Task<ChiTietDichVuVM> AddAsync(AddChiTietDichVu model);
        Task<bool> UpdateAsync(int id, UpdateChiTietDichVu model);
        Task<bool> DeleteAsync(int id);
    }

    public class ChiTietDichVuRepository : IChiTietDichVuRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietDichVuRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiTietDichVuVM>> GetAllAsync()
        {
            return await _context.ChiTietDichVus.Select(c => new ChiTietDichVuVM
            {
                IdChiTietDichVu = c.IdChiTietDichVu,
                IdDichVu = c.IdDichVu,
                SoLuong = c.SoLuong,
                TongTien = c.TongTien
            }).ToListAsync();
        }

        public async Task<ChiTietDichVuVM?> GetByIdAsync(int id)
        {
            var chiTietDichVu = await _context.ChiTietDichVus.FindAsync(id);
            if (chiTietDichVu == null) return null;

            return new ChiTietDichVuVM
            {
                IdChiTietDichVu = chiTietDichVu.IdChiTietDichVu,
                IdDichVu = chiTietDichVu.IdDichVu,
                SoLuong = chiTietDichVu.SoLuong,
                TongTien = chiTietDichVu.TongTien
            };
        }

        public async Task<ChiTietDichVuVM> AddAsync(AddChiTietDichVu model)
        {
            var chiTietDichVu = new ChiTietDichVu
            {
                IdDichVu = model.IdDichVu,
                SoLuong = model.SoLuong,
                TongTien = model.TongTien
            };

            _context.ChiTietDichVus.Add(chiTietDichVu);
            await _context.SaveChangesAsync();

            return new ChiTietDichVuVM
            {
                IdChiTietDichVu = chiTietDichVu.IdChiTietDichVu,
                IdDichVu = chiTietDichVu.IdDichVu,
                SoLuong = chiTietDichVu.SoLuong,
                TongTien = chiTietDichVu.TongTien
            };
        }


        public async Task<bool> UpdateAsync(int id, UpdateChiTietDichVu model)
        {
            var chiTietDichVu = await _context.ChiTietDichVus.FindAsync(id);
            if (chiTietDichVu == null) return false;

            chiTietDichVu.IdDichVu = model.IdDichVu;
            chiTietDichVu.SoLuong = model.SoLuong;
            chiTietDichVu.TongTien = model.TongTien;

            _context.ChiTietDichVus.Update(chiTietDichVu);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var chiTietDichVu = await _context.ChiTietDichVus.FindAsync(id);
            if (chiTietDichVu == null) return false;

            _context.ChiTietDichVus.Remove(chiTietDichVu);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
