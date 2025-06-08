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
    public class KhachHangController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public KhachHangController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/KhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetKhachHangs()
        {
            return await _context.KhachHangs
                .Include(kh => kh.ChiTietDatPhongs)
                .Include(kh => kh.DatPhongs)
                .ToListAsync();
        }

        // GET: api/KhachHang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(int id)
        {
            var khachHang = await _context.KhachHangs
                .Include(kh => kh.ChiTietDatPhongs)
                .Include(kh => kh.DatPhongs)
                .FirstOrDefaultAsync(kh => kh.IdKhachHang == id);

            if (khachHang == null)
            {
                return NotFound($"Khách hàng với ID {id} không tồn tại.");
            }

            return Ok(khachHang);
        }

        // POST: api/KhachHang
        [HttpPost]
        public async Task<ActionResult<KhachHang>> PostKhachHang(KhachHang khachHang)
        {
            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKhachHang), new { id = khachHang.IdKhachHang }, khachHang);
        }

        // PUT: api/KhachHang/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachHang(int id, KhachHang khachHang)
        {
            if (id != khachHang.IdKhachHang)
            {
                return BadRequest();
            }

            _context.Entry(khachHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachHangExists(id))
                {
                    return NotFound($"Khách hàng với ID {id} không tồn tại.");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Đã cập nhật khách hàng với ID {id} thành công.");
        }

        // DELETE: api/KhachHang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(int id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound($"Khách hàng với ID {id} không tồn tại.");
            }

            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();

            return Ok($"Đã xóa khách hàng với ID {id} thành công.");
        }

        private bool KhachHangExists(int id)
        {
            return _context.KhachHangs.Any(e => e.IdKhachHang == id);
        }
    }
}