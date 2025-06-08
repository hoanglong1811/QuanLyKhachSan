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
    public class LoaiPhongController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public LoaiPhongController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/LoaiPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiPhong>>> GetLoaiPhongs()
        {
            return await _context.LoaiPhongs.ToListAsync();
        }

        // GET: api/LoaiPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiPhong>> GetLoaiPhong(int id)
        {
            var loaiPhong = await _context.LoaiPhongs.FindAsync(id);

            if (loaiPhong == null)
            {
                return NotFound($"Loại phòng với ID {id} không tồn tại.");
            }

            return Ok(loaiPhong);
        }

        // POST: api/LoaiPhong
        [HttpPost]
        public async Task<ActionResult<LoaiPhong>> PostLoaiPhong(LoaiPhong loaiPhong)
        {
            _context.LoaiPhongs.Add(loaiPhong);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLoaiPhong), new { id = loaiPhong.IdLoaiPhong }, loaiPhong);
        }

        // PUT: api/LoaiPhong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiPhong(int id, LoaiPhong loaiPhong)
        {
            if (id != loaiPhong.IdLoaiPhong)
            {
                return BadRequest();
            }

            _context.Entry(loaiPhong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiPhongExists(id))
                {
                    return NotFound($"Loại phòng với ID {id} không tồn tại.");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Đã cập nhật loại phòng với ID {id} thành công.");
        }

        // DELETE: api/LoaiPhong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiPhong(int id)
        {
            var loaiPhong = await _context.LoaiPhongs.FindAsync(id);
            if (loaiPhong == null)
            {
                return NotFound($"Loại phòng với ID {id} không tồn tại.");
            }

            _context.LoaiPhongs.Remove(loaiPhong);
            await _context.SaveChangesAsync();

            return Ok($"Đã xóa loại phòng với ID {id} thành công.");
        }

        private bool LoaiPhongExists(int id)
        {
            return _context.LoaiPhongs.Any(e => e.IdLoaiPhong == id);
        }
    }
}