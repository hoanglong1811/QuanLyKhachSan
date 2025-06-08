using back_end.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.ViewModels;

namespace back_end.Services
{
    public interface ILoaiPhongRepository
    {
        Task<IEnumerable<LoaiPhongVM>> GetAllAsync();
        Task<LoaiPhongVM?> GetByIdAsync(int id);
        Task<LoaiPhongVM> AddAsync(AddLoaiPhong entity);
        Task<bool> UpdateAsync(int id, UpdateLoaiPhong entity);
        Task<bool> DeleteAsync(int id);
    }

    public class LoaiPhongRepository : ILoaiPhongRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public LoaiPhongRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        private static LoaiPhongVM ToVM(LoaiPhong entity)
        {
            return new LoaiPhongVM
            {
                IdLoaiPhong = entity.IdLoaiPhong,
                TenLoaiPhong = entity.TenLoaiPhong,
                MoTa = entity.MoTa,
                Gia = entity.Gia
            };
        }

        public async Task<IEnumerable<LoaiPhongVM>> GetAllAsync()
        {
            var list = await _context.LoaiPhongs.ToListAsync();
            return list.Select(ToVM);
        }

        public async Task<LoaiPhongVM?> GetByIdAsync(int id)
        {
            var entity = await _context.LoaiPhongs.FindAsync(id);
            return entity == null ? null : ToVM(entity);
        }

        public async Task<LoaiPhongVM> AddAsync(AddLoaiPhong model)
        {
            var entity = new LoaiPhong
            {
                TenLoaiPhong = model.TenLoaiPhong,
                MoTa = model.MoTa,
                Gia = model.Gia
            };
            _context.LoaiPhongs.Add(entity);
            await _context.SaveChangesAsync();
            return ToVM(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateLoaiPhong model)
        {
            var entity = await _context.LoaiPhongs.FindAsync(id);
            if (entity == null) return false;
            entity.TenLoaiPhong = model.TenLoaiPhong ?? entity.TenLoaiPhong;
            entity.MoTa = model.MoTa ?? entity.MoTa;
            if (model.Gia.HasValue) entity.Gia = model.Gia;
            _context.LoaiPhongs.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.LoaiPhongs.FindAsync(id);
            if (entity == null) return false;
            _context.LoaiPhongs.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
