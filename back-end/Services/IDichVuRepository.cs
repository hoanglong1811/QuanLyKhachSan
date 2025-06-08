using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace back_end.Services
{
    public interface IDichVuRepository
    {
        Task<IEnumerable<DichVuVM>> GetAllAsync();
        Task<DichVuVM?> GetByIdAsync(int id);
        Task<DichVuVM> AddAsync(AddDichVu model);
        Task<bool> UpdateAsync(int id, UpdateDichVu model);
        Task<bool> DeleteAsync(int id);
    }

    public class DichVuRepository : IDichVuRepository
    {
        private readonly DataQlks114Nhom3Context _context;

        public DichVuRepository(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        private static DichVuVM ToVM(DichVu entity)
        {
            return new DichVuVM
            {
                IdDichVu = entity.IdDichVu,
                TenDichVu = entity.TenDichVu,
                Gia = entity.Gia,
                DonViTinh = entity.DonViTinh,
                MoTa = entity.MoTa
            };
        }

        public async Task<IEnumerable<DichVuVM>> GetAllAsync()
        {
            var entities = await _context.DichVus.ToListAsync();
            return entities.ConvertAll(ToVM);
        }

        public async Task<DichVuVM?> GetByIdAsync(int id)
        {
            var entity = await _context.DichVus.FindAsync(id);
            return entity == null ? null : ToVM(entity);
        }

        public async Task<DichVuVM> AddAsync(AddDichVu model)
        {
            var entity = new DichVu
            {
                TenDichVu = model.TenDichVu,
                Gia = model.Gia,
                DonViTinh = model.DonViTinh,
                MoTa = model.MoTa
            };
            _context.DichVus.Add(entity);
            await _context.SaveChangesAsync();
            return ToVM(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateDichVu model)
        {
            var entity = await _context.DichVus.FindAsync(id);
            if (entity == null) return false;
            entity.TenDichVu = model.TenDichVu;
            entity.Gia = model.Gia;
            entity.DonViTinh = model.DonViTinh;
            entity.MoTa = model.MoTa;
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.DichVus.FindAsync(id);
            if (entity == null) return false;
            _context.DichVus.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
