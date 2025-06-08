using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace back_end.Services
{
    public interface IKhachHangRepository
    {
        Task<IEnumerable<KhachHangVM>> GetAllAsync();
        Task<KhachHangVM?> GetByIdAsync(int id);
        Task<KhachHang> AddAsync(AddKhachHang model);
        Task<bool> UpdateAsync(int id, UpdateKhachHang model);
        Task<bool> DeleteAsync(int id);
        Task<bool> KhachHangExistsAsync(int id);
        Task<KhachHangVM?> GetKhachHangByPhoneAsync(int phone);
        Task<KhachHangVM?> GetKhachHangByCccdAsync(string cccd);
        Task<IEnumerable<KhachHangVM>> SearchKhachHangAsync(string searchTerm);
    }

    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public KhachHangRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KhachHangVM>> GetAllAsync()
        {
            return await _context.KhachHangs
                .Select(kh => new KhachHangVM
                {
                    IdKhachHang = kh.IdKhachHang,
                    HoTen = kh.HoTen,
                    DienThoai = kh.DienThoai,
                    Cccd = kh.Cccd,
                    
                })
                .ToListAsync();
        }

        public async Task<KhachHangVM?> GetByIdAsync(int id)
        {
            return await _context.KhachHangs
                .Where(kh => kh.IdKhachHang == id)
                .Select(kh => new KhachHangVM
                {
                    IdKhachHang = kh.IdKhachHang,
                    HoTen = kh.HoTen,
                    DienThoai = kh.DienThoai,
                    Cccd = kh.Cccd,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<KhachHang> AddAsync(AddKhachHang model)
        {
            var entity = new KhachHang
            {
                HoTen = model.HoTen,
                DienThoai = model.DienThoai,
                Cccd = model.Cccd,
                // Gán các trường khác nếu có
            };
            _context.KhachHangs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, UpdateKhachHang model)
        {
            var entity = await _context.KhachHangs.FindAsync(id);
            if (entity == null) return false;

            entity.HoTen = model.HoTen;
            entity.DienThoai = model.DienThoai;
            entity.Cccd = model.Cccd;
            // Cập nhật các trường khác nếu có

            _context.KhachHangs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.KhachHangs.FindAsync(id);
            if (entity == null) return false;

            _context.KhachHangs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> KhachHangExistsAsync(int id)
        {
            return await _context.KhachHangs.AnyAsync(kh => kh.IdKhachHang == id);
        }

        public async Task<KhachHangVM?> GetKhachHangByPhoneAsync(int phone)
        {
            return await _context.KhachHangs
                .Where(kh => kh.DienThoai == phone)
                .Select(kh => new KhachHangVM
                {
                    IdKhachHang = kh.IdKhachHang,
                    HoTen = kh.HoTen,
                    DienThoai = kh.DienThoai,
                    Cccd = kh.Cccd,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<KhachHangVM?> GetKhachHangByCccdAsync(string cccd)
        {
            return await _context.KhachHangs
                .Where(kh => kh.Cccd == cccd)
                .Select(kh => new KhachHangVM
                {
                    IdKhachHang = kh.IdKhachHang,
                    HoTen = kh.HoTen,
                    DienThoai = kh.DienThoai,
                    Cccd = kh.Cccd,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<KhachHangVM>> SearchKhachHangAsync(string searchTerm)
        {
            return await _context.KhachHangs
                .Where(kh => (kh.HoTen ?? "").Contains(searchTerm) || (kh.Cccd ?? "").Contains(searchTerm))
                .Select(kh => new KhachHangVM
                {
                    IdKhachHang = kh.IdKhachHang,
                    HoTen = kh.HoTen,
                    DienThoai = kh.DienThoai,
                    Cccd = kh.Cccd,
                })
                .ToListAsync();
        }
    }
}
