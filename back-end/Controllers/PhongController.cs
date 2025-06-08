using Microsoft.AspNetCore.Mvc;
using back_end.Data;
using back_end.Services;
using back_end.ViewModels;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly IPhongRepository _phongRepository;
        private readonly ILoaiPhongRepository _loaiPhongRepository;

        public PhongController(IPhongRepository phongRepository, ILoaiPhongRepository loaiPhongRepository)
        {
            _phongRepository = phongRepository;
            _loaiPhongRepository = loaiPhongRepository;
        }

        // GET: api/Phong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhongVM>>> GetPhongs()
        {
            var phongs = await _phongRepository.GetAllAsync();
            return Ok(phongs);
        }

        // GET: api/Phong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhongVM>> GetPhong(int id)
        {
            var phong = await _phongRepository.GetByIdAsync(id);

            if (phong == null)
            {
                return NotFound("Không tìm thấy phòng");
            }

            return Ok(phong);
        }

        // POST: api/Phong
        [HttpPost]
        public async Task<ActionResult<PhongVM>> PostPhong(AddPhong model)
        {
            // Kiểm tra sự tồn tại của IdLoaiPhong
            var loaiPhong = await _loaiPhongRepository.GetByIdAsync(model.IdLoaiPhong);
            if (loaiPhong == null)
            {
                return BadRequest($"Loại phòng với ID {model.IdLoaiPhong} không tồn tại");
            }

            var phong = await _phongRepository.AddAsync(model);
            return CreatedAtAction(nameof(GetPhong), new { id = phong.IdPhong }, phong);
        }

        // PUT: api/Phong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhong(int id, UpdatePhong model)
        {
            // Kiểm tra sự tồn tại của IdLoaiPhong
            var loaiPhong = await _loaiPhongRepository.GetByIdAsync(model.IdLoaiPhong);
            if (loaiPhong == null)
            {
                return BadRequest($"Loại phòng với ID {model.IdLoaiPhong} không tồn tại");
            }

            var result = await _phongRepository.UpdateAsync(id, model);
            
            if (!result)
            {
                return NotFound("Không tìm thấy phòng");
            }

            return Ok($"Cập nhật phòng thành công");
        }

        // DELETE: api/Phong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhong(int id)
        {
            var result = await _phongRepository.DeleteAsync(id);
            
            if (!result)
            {
                return NotFound("Không tìm thấy phòng");
            }

            return Ok($"Xóa phòng thành công");
        }
    }
}