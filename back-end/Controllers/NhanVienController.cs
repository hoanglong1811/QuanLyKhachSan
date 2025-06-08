using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;
using back_end.Services;
using back_end.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public NhanVienController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/NhanVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetNhanViens()
        {
            return await _context.NhanViens
                .Include(nv => nv.IdTaiKhoanNavigation)
                .ToListAsync();
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(int id)
        {
            var nhanVien = await _context.NhanViens
                .Include(nv => nv.IdTaiKhoanNavigation)
                .FirstOrDefaultAsync(nv => nv.IdNhanVien == id);

            if (nhanVien == null)
            {
                return NotFound($"Nhân viên với ID {id} không tồn tại.");
            }

            return Ok(nhanVien);
        }

        // POST: api/NhanVien
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien(NhanVien nhanVien)
        {
            _context.NhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNhanVien), new { id = nhanVien.IdNhanVien }, nhanVien);
        }

        // PUT: api/NhanVien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(int id, NhanVien nhanVien)
        {
            if (id != nhanVien.IdNhanVien)
            {
                return BadRequest();
            }

            _context.Entry(nhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
                {
                    return NotFound($"Nhân viên với ID {id} không tồn tại.");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Đã cập nhật nhân viên với ID {id} thành công.");
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound($"Nhân viên với ID {id} không tồn tại.");
            }

            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();

            return Ok($"Đã xóa nhân viên với ID {id} thành công.");
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.IdNhanVien == id);
        }
    }
}