using Microsoft.AspNetCore.Mvc;
using back_end.Services;
using back_end.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuBaoTriController : ControllerBase
    {
        private readonly IPhieuBaoTriRepository _repository;

        public PhieuBaoTriController(IPhieuBaoTriRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PhieuBaoTri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuBaoTriVM>>> GetPhieuBaoTris()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/PhieuBaoTri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuBaoTriVM>> GetPhieuBaoTri(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return NotFound($"PhieuBaoTri with ID {id} not found.");
            return Ok(result);
        }

        // POST: api/PhieuBaoTri
        [HttpPost]
        public async Task<ActionResult<PhieuBaoTriVM>> PostPhieuBaoTri(AddPhieuBaoTri model)
        {
            var result = await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetPhieuBaoTri), new { id = result.Id }, result);
        }

        // PUT: api/PhieuBaoTri/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuBaoTri(int id, UpdatePhieuBaoTri model)
        {
            var success = await _repository.UpdateAsync(id, model);
            if (!success)
                return NotFound();
            return Ok($"Cập nhật phiếu bảo trì với ID {id} thành công.");
        }

        // DELETE: api/PhieuBaoTri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieuBaoTri(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return NotFound($"Không tìm thấy phiếu bảo trì với ID {id}.");
            return Ok($"Đã xóa phiếu bảo trì với ID {id} thành công.");
        }
    }
}