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
        private readonly ILoaiPhongRepository _repo;

        public LoaiPhongController(ILoaiPhongRepository repo)
        {
            _repo = repo;
        }

        // GET: api/LoaiPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiPhongVM>>> GetLoaiPhongs()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        // GET: api/LoaiPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiPhongVM>> GetLoaiPhong(int id)
        {
            var loaiPhong = await _repo.GetByIdAsync(id);
            if (loaiPhong == null)
            {
                return NotFound($"Loại phòng với ID {id} không tồn tại.");
            }
            return Ok(loaiPhong);
        }

        // POST: api/LoaiPhong
        [HttpPost]
        public async Task<ActionResult<LoaiPhongVM>> PostLoaiPhong(AddLoaiPhong model)
        {
            var result = await _repo.AddAsync(model);
            return CreatedAtAction(nameof(GetLoaiPhong), new { id = result.IdLoaiPhong }, result);
        }

        // PUT: api/LoaiPhong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiPhong(int id, UpdateLoaiPhong model)
        {
            var success = await _repo.UpdateAsync(id, model);
            if (!success)
            {
                return NotFound($"Loại phòng với ID {id} không tồn tại.");
            }
            return Ok($"Đã cập nhật loại phòng với ID {id} thành công.");
        }

        // DELETE: api/LoaiPhong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiPhong(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"Loại phòng với ID {id} không tồn tại.");
            }
            return Ok($"Đã xóa loại phòng với ID {id} thành công.");
        }
    }
}