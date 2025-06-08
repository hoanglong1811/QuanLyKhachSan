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
        private readonly INhanVienRepository _nhanVienRepository;

        public NhanVienController(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        // GET: api/NhanVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVienVM>>> GetNhanViens()
        {
            var result = await _nhanVienRepository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVienVM>> GetNhanVien(int id)
        {
            var nhanVien = await _nhanVienRepository.GetByIdAsync(id);
            if (nhanVien == null)
            {
                return NotFound($"Nhân viên với ID {id} không tồn tại.");
            }
            return Ok(nhanVien);
        }

        // POST: api/NhanVien
        [HttpPost]
        public async Task<ActionResult<NhanVienVM>> PostNhanVien([FromBody] AddNhanVien model)
        {
            var result = await _nhanVienRepository.AddAsync(model);
            return CreatedAtAction(nameof(GetNhanVien), new { id = result.IdNhanVien }, result);
        }

        // PUT: api/NhanVien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(int id, [FromBody] UpdateNhanVien model)
        {
            var success = await _nhanVienRepository.UpdateAsync(id, model);
            if (!success)
            {
                return NotFound($"Nhân viên với ID {id} không tồn tại.");
            }
            return Ok($"Đã cập nhật nhân viên với ID {id} thành công.");
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(int id)
        {
            var success = await _nhanVienRepository.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"Nhân viên với ID {id} không tồn tại.");
            }
            return Ok($"Đã xóa nhân viên với ID {id} thành công.");
        }
    }
}