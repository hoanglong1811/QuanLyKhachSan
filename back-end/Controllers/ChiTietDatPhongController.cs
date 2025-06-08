using Microsoft.AspNetCore.Mvc;
using back_end.Services;
using back_end.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDatPhongController : ControllerBase
    {
        private readonly IChiTietDatPhongRepository _repository;

        public ChiTietDatPhongController(IChiTietDatPhongRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ChiTietDatPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDatPhongVM>>> GetChiTietDatPhongs()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/ChiTietDatPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDatPhongVM>> GetChiTietDatPhong(int id)
        {
            var chiTiet = await _repository.GetByIdAsync(id);
            if (chiTiet == null)
                return NotFound($"Chi tiết đặt phòng với ID {id} không tồn tại.");
            return Ok(chiTiet);
        }

        // POST: api/ChiTietDatPhong
        [HttpPost]
        public async Task<ActionResult<ChiTietDatPhongVM>> PostChiTietDatPhong([FromBody] AddChiTietDatPhong model)
        {
            var result = await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetChiTietDatPhong), new { id = result.IdChiTietDatPhong }, result);
        }

        // PUT: api/ChiTietDatPhong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDatPhong(int id, [FromBody] UpdateChiTietDatPhong model)
        {
            if (id != model.IdChiTietDatPhong)
                return BadRequest();

            var result = await _repository.UpdateAsync(id, model);
            if (!result)
                return NotFound($"Chi tiết đặt phòng với ID {id} không tồn tại.");
            return Ok($"Đã cập nhật chi tiết đặt phòng với ID {id} thành công.");
        }

        // DELETE: api/ChiTietDatPhong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDatPhong(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound($"Chi tiết đặt phòng với ID {id} không tồn tại.");
            return Ok($"Đã xóa chi tiết đặt phòng với ID {id} thành công.");
        }
    }
}