using Microsoft.AspNetCore.Mvc;
using back_end.Services;
using back_end.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDichVuController : ControllerBase
    {
        private readonly IChiTietDichVuRepository _repository;

        public ChiTietDichVuController(IChiTietDichVuRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ChiTietDichVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDichVuVM>>> GetChiTietDichVus()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/ChiTietDichVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDichVuVM>> GetChiTietDichVu(int id)
        {
            var chiTiet = await _repository.GetByIdAsync(id);
            if (chiTiet == null)
                return NotFound($"Chi tiết dịch vụ với ID {id} không tồn tại.");
            return Ok(chiTiet);
        }

        // POST: api/ChiTietDichVu
        [HttpPost]
        public async Task<ActionResult<ChiTietDichVuVM>> PostChiTietDichVu([FromBody] AddChiTietDichVu model)
        {
            var result = await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetChiTietDichVu), new { id = result.IdChiTietDichVu }, result);
        }

        // PUT: api/ChiTietDichVu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDichVu(int id, [FromBody] UpdateChiTietDichVu model)
        {
            if (id != model.IdDichVu)
                return BadRequest();

            var result = await _repository.UpdateAsync(id, model);
            if (!result)
                return NotFound($"Chi tiết dịch vụ với ID {id} không tồn tại.");
            return Ok($"Đã cập nhật chi tiết dịch vụ với ID {id} thành công.");
        }

        // DELETE: api/ChiTietDichVu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDichVu(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound($"Chi tiết dịch vụ với ID {id} không tồn tại.");
            return Ok($"Đã xóa chi tiết dịch vụ với ID {id} thành công.");
        }
    }
}