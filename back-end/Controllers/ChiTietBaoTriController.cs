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
    public class ChiTietBaoTriController : ControllerBase
    {
        private readonly IChiTietBaoTriRepository _repository;

        public ChiTietBaoTriController(IChiTietBaoTriRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ChiTietBaoTri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietBaoTriVM>>> GetChiTietBaoTris()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/ChiTietBaoTri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietBaoTriVM>> GetChiTietBaoTri(int id)
        {
            var chiTiet = await _repository.GetByIdAsync(id);
            if (chiTiet == null)
            {
                return NotFound($"Chi tiết bảo trì với ID {id} không tồn tại.");
            }
            return Ok(chiTiet);
        }

        // POST: api/ChiTietBaoTri
        [HttpPost]
        public async Task<IActionResult> PostChiTietBaoTri(AddChiTietBaoTri model)
        {
            await _repository.AddAsync(model);
            return Ok("Đã thêm chi tiết bảo trì thành công.");
        }

        // PUT: api/ChiTietBaoTri/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietBaoTri(int id, UpdateChiTietBaoTri model)
        {
            if (id != model.IdChiTietBaoTri)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(model);
            return Ok($"Đã cập nhật chi tiết bảo trì với ID {id} thành công.");
        }

        // DELETE: api/ChiTietBaoTri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietBaoTri(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Chi tiết bảo trì với ID {id} không tồn tại.");
            }
            return Ok($"Đã xóa chi tiết bảo trì với ID {id} thành công.");
        }
    }
}