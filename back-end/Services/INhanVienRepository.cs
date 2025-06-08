using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace back_end.Services
{
    public interface INhanVienRepository
    {
        Task<IEnumerable<NhanVienVM>> GetAllAsync();
        Task<NhanVienVM?> GetByIdAsync(int id);
        Task<NhanVienVM> AddAsync(AddNhanVien model);
        Task<bool> UpdateAsync(int id, UpdateNhanVien model);
        Task<bool> DeleteAsync(int id);
    }

    public class NhanVienRepository : INhanVienRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public NhanVienRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NhanVienVM>> GetAllAsync()
        {
            return await _context.NhanViens
                .Include(nv => nv.IdTaiKhoanNavigation)
                .Select(nv => new NhanVienVM
                {
                    IdNhanVien = nv.IdNhanVien,
                    HoTen = nv.HoTen,
                    DiaChi = nv.DiaChi,
                    GioiTinh = nv.GioiTinh,
                    DienThoai = nv.DienThoai,
                    IdTaiKhoan = nv.IdTaiKhoan,
                    TenTaiKhoan = nv.IdTaiKhoanNavigation.TenDangNhap,
                    Email = nv.IdTaiKhoanNavigation.Email,
                    VaiTro = nv.IdTaiKhoanNavigation.IdVaiTroNavigation.TenVaiTro,
                    IsActive = true // Nếu có trường này trong entity thì lấy từ entity
                }).ToListAsync();
        }

        public async Task<NhanVienVM?> GetByIdAsync(int id)
        {
            var nv = await _context.NhanViens
                .Include(nv => nv.IdTaiKhoanNavigation)
                .ThenInclude(tk => tk.IdVaiTroNavigation)
                .FirstOrDefaultAsync(nv => nv.IdNhanVien == id);
            if (nv == null) return null;
            return new NhanVienVM
            {
                IdNhanVien = nv.IdNhanVien,
                HoTen = nv.HoTen,
                DiaChi = nv.DiaChi,
                GioiTinh = nv.GioiTinh,
                DienThoai = nv.DienThoai,
                IdTaiKhoan = nv.IdTaiKhoan,
                TenTaiKhoan = nv.IdTaiKhoanNavigation.TenDangNhap,
                Email = nv.IdTaiKhoanNavigation.Email,
                VaiTro = nv.IdTaiKhoanNavigation.IdVaiTroNavigation.TenVaiTro,
                IsActive = true // Nếu có trường này trong entity thì lấy từ entity
            };
        }

        public async Task<NhanVienVM> AddAsync(AddNhanVien model)
        {
            var entity = new NhanVien
            {
                HoTen = model.HoTen,
                DiaChi = model.DiaChi,
                GioiTinh = model.GioiTinh,
                DienThoai = model.DienThoai,
                IdTaiKhoan = model.IdTaiKhoan
            };
            _context.NhanViens.Add(entity);
            await _context.SaveChangesAsync();
            // Lấy lại entity kèm navigation
            return await GetByIdAsync(entity.IdNhanVien) ?? throw new Exception("Add failed");
        }

        public async Task<bool> UpdateAsync(int id, UpdateNhanVien model)
        {
            var entity = await _context.NhanViens.FindAsync(id);
            if (entity == null) return false;
            entity.HoTen = model.HoTen;
            entity.DiaChi = model.DiaChi;
            entity.GioiTinh = model.GioiTinh;
            entity.DienThoai = model.DienThoai;
            // Nếu có IsActive trong entity thì cập nhật
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.NhanViens.FindAsync(id);
            if (entity == null) return false;
            _context.NhanViens.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
