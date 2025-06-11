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
    public class DatPhongController : ControllerBase
    {
        private readonly IDatPhongRepository _repository;

        public DatPhongController(IDatPhongRepository repository)
        {
            _repository = repository;
        }

        // GET: api/DatPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatPhongVM>>> GetDatPhongs()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/DatPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatPhongVM>> GetDatPhong(int id)
        {
            var datPhong = await _repository.GetByIdAsync(id);
            if (datPhong is null)
            {
                return NotFound($"Đặt phòng với ID {id} không tồn tại.");
            }
            return Ok(datPhong);
        }

        // POST: api/DatPhong
        [HttpPost]
        public async Task<ActionResult<DatPhongVM>> PostDatPhong([FromBody] AddDatPhong model)
        {
            var datPhong = await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetDatPhong), new { id = datPhong.IdDatPhong }, datPhong);
        }

        // PUT: api/DatPhong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatPhong(int id, [FromBody] UpdateDatPhong model)
        {
            if (id != model.IdDatPhong)
            {
                return BadRequest();
            }
            var result = await _repository.UpdateAsync(id, model);
            if (!result)
            {
                return NotFound($"Đặt phòng với ID {id} không tồn tại.");
            }
            return Ok($"Đặt phòng với ID {id} đã được cập nhật thành công.");
        }

        // DELETE: api/DatPhong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatPhong(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Đặt phòng với ID {id} không tồn tại.");
            }
            return Ok($"Đã xóa đặt phòng với ID {id} thành công.");
        }
    }
}