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
    public class DichVuController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public DichVuController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/DichVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DichVu>>> GetDichVus()
        {
            return await _context.DichVus.ToListAsync();
        }

        // GET: api/DichVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DichVu>> GetDichVu(int id)
        {
            var dichVu = await _context.DichVus.FindAsync(id);

            if (dichVu == null)
            {
                return NotFound($"Dịch vụ với ID {id} không tồn tại.");
            }

            return Ok(dichVu);
        }

        // POST: api/DichVu
        [HttpPost]
        public async Task<ActionResult<DichVu>> PostDichVu(DichVu dichVu)
        {
            _context.DichVus.Add(dichVu);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDichVu), new { id = dichVu.IdDichVu }, dichVu);
        }

        // PUT: api/DichVu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDichVu(int id, DichVu dichVu)
        {
            if (id != dichVu.IdDichVu)
            {
                return BadRequest();
            }

            _context.Entry(dichVu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DichVuExists(id))
                {
                    return NotFound($"Dịch vụ với ID {id} không tồn tại.");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Đã cập nhật dịch vụ với ID {id} thành công.");
        }

        // DELETE: api/DichVu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDichVu(int id)
        {
            var dichVu = await _context.DichVus.FindAsync(id);
            if (dichVu == null)
            {
                return NotFound($"Dịch vụ với ID {id} không tồn tại.");
            }

            _context.DichVus.Remove(dichVu);
            await _context.SaveChangesAsync();

            return Ok($"Đã xóa dịch vụ với ID {id} thành công.");
        }

        private bool DichVuExists(int id)
        {
            return _context.DichVus.Any(e => e.IdDichVu == id);
        }
    }
}