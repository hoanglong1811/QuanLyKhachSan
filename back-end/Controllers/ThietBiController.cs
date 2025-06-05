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
    public class ThietBiController : ControllerBase
    {
        private readonly IThietBiRepository _thietBiRepository;
        private readonly DataQlks114Nhom3Context _context;

        public ThietBiController(IThietBiRepository thietBiRepository, DataQlks114Nhom3Context context)
        {
            _thietBiRepository = thietBiRepository;
            _context = context;
        }

        // GET: api/ThietBi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThietBiVM>>> GetThietBis()
        {
            try
            {
                var thietBis = await _thietBiRepository.GetAllWithDetailsAsync();
                return Ok(new { message = "Lấy danh sách thiết bị thành công", data = thietBis });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách thiết bị", error = ex.Message });
            }
        }

        // GET: api/ThietBi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThietBiVM>> GetThietBi(int id)
        {
            try
            {
                var thietBi = await _thietBiRepository.GetByIdWithDetailsAsync(id);
                if (thietBi == null)
                {
                    return NotFound(new { message = $"Không tìm thấy thiết bị với ID {id}" });
                }

                return Ok(new { message = "Lấy thông tin thiết bị thành công", data = thietBi });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin thiết bị", error = ex.Message });
            }
        }

        // GET: api/ThietBi/phong/{idPhong}
        [HttpGet("phong/{idPhong}")]
        public async Task<ActionResult<IEnumerable<ThietBiVM>>> GetThietBisByPhong(int idPhong)
        {
            try
            {
                var phong = await _context.Phongs.FindAsync(idPhong);
                if (phong == null)
                {
                    return NotFound(new { message = $"Không tìm thấy phòng với ID {idPhong}" });
                }

                var thietBis = await _thietBiRepository.GetByPhongIdAsync(idPhong);
                return Ok(new { 
                    message = $"Lấy danh sách thiết bị của phòng {phong.SoPhong} thành công", 
                    data = thietBis 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách thiết bị theo phòng", error = ex.Message });
            }
        }

        // GET: api/ThietBi/baotri
        [HttpGet("baotri")]
        public async Task<ActionResult<IEnumerable<ThietBi>>> GetThietBiCanBaoTri()
        {
            try
            {
                var thietBis = await _thietBiRepository.GetThietBiCanBaoTriAsync();
                return Ok(new { message = "Lấy danh sách thiết bị cần bảo trì thành công", data = thietBis });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách thiết bị cần bảo trì", error = ex.Message });
            }
        }

        // GET: api/ThietBi/count/phong/{idPhong}
        [HttpGet("count/phong/{idPhong}")]
        public async Task<ActionResult<int>> CountThietBiByPhong(int idPhong)
        {
            try
            {
                var phong = await _context.Phongs.FindAsync(idPhong);
                if (phong == null)
                {
                    return NotFound(new { message = $"Không tìm thấy phòng với ID {idPhong}" });
                }

                var count = await _thietBiRepository.CountThietBiByPhongAsync(idPhong);
                return Ok(new { 
                    message = $"Số lượng thiết bị trong phòng {phong.SoPhong}", 
                    data = count 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi đếm số lượng thiết bị trong phòng", error = ex.Message });
            }
        }

        // POST: api/ThietBi
        [HttpPost]
        public async Task<ActionResult<ThietBiVM>> PostThietBi(AddThietBi model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dữ liệu không hợp lệ", errors = ModelState });
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(model.TenThietBi))
                {
                    return BadRequest(new { message = "Tên thiết bị không được để trống" });
                }

                if (string.IsNullOrWhiteSpace(model.LoaiThietBi))
                {
                    return BadRequest(new { message = "Loại thiết bị không được để trống" });
                }

                if (string.IsNullOrWhiteSpace(model.TinhTrang))
                {
                    return BadRequest(new { message = "Tình trạng thiết bị không được để trống" });
                }

                if (model.SoLuong <= 0)
                {
                    return BadRequest(new { message = "Số lượng thiết bị phải lớn hơn 0" });
                }

                if (model.Gia < 0)
                {
                    return BadRequest(new { message = "Giá thiết bị không được âm" });
                }

                // Validate if room exists
                var phong = await _context.Phongs.FindAsync(model.IdPhong);
                if (phong == null)
                {
                    return BadRequest(new { message = $"Phòng với ID {model.IdPhong} không tồn tại" });
                }

                // Check if room status allows adding equipment
                if (phong.TrangThai == "Đang sử dụng" || phong.TrangThai == "Đang bảo trì")
                {
                    return BadRequest(new { message = $"Không thể thêm thiết bị vào phòng đang {phong.TrangThai.ToLower()}" });
                }

                // Map AddThietBi to ThietBi entity
                var thietBi = new ThietBi
                {
                    TenThietBi = model.TenThietBi,
                    LoaiThietBi = model.LoaiThietBi,
                    TinhTrang = string.IsNullOrWhiteSpace(model.TinhTrang) ? "Mới" : model.TinhTrang,
                    Gia = model.Gia,
                    SoLuong = model.SoLuong,
                    IdPhong = model.IdPhong
                };

                // Add the equipment using repository
                var addedThietBi = await _thietBiRepository.AddAsync(thietBi);

                // Get the added equipment with details
                var thietBiVM = await _thietBiRepository.GetByIdWithDetailsAsync(addedThietBi.IdThietBi);
                if (thietBiVM == null)
                {
                    return StatusCode(500, new { message = "Lỗi khi lấy thông tin thiết bị sau khi thêm" });
                }

                return CreatedAtAction(nameof(GetThietBi), 
                    new { id = thietBiVM.IdThietBi }, 
                    new { 
                        message = "Thêm thiết bị thành công",
                        data = thietBiVM 
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    message = "Lỗi khi thêm thiết bị", 
                    error = ex.Message,
                    details = ex.InnerException?.Message 
                });
            }
        }

        // PUT: api/ThietBi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThietBi(int id, UpdateThietBi model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Dữ liệu không hợp lệ", errors = ModelState });
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(model.TenThietBi))
                {
                    return BadRequest(new { message = "Tên thiết bị không được để trống" });
                }

                if (string.IsNullOrWhiteSpace(model.LoaiThietBi))
                {
                    return BadRequest(new { message = "Loại thiết bị không được để trống" });
                }

                if (string.IsNullOrWhiteSpace(model.TinhTrang))
                {
                    return BadRequest(new { message = "Tình trạng thiết bị không được để trống" });
                }

                if (model.SoLuong <= 0)
                {
                    return BadRequest(new { message = "Số lượng thiết bị phải lớn hơn 0" });
                }

                if (model.Gia < 0)
                {
                    return BadRequest(new { message = "Giá thiết bị không được âm" });
                }

                // Check if equipment exists
                var existingThietBi = await _thietBiRepository.GetByIdAsync(id);
                if (existingThietBi == null)
                {
                    return NotFound(new { message = $"Không tìm thấy thiết bị với ID {id}" });
                }

                // Validate if room exists
                var phong = await _context.Phongs.FindAsync(model.IdPhong);
                if (phong == null)
                {
                    return BadRequest(new { message = $"Phòng với ID {model.IdPhong} không tồn tại" });
                }

                // Check if room status allows updating equipment
                if (phong.TrangThai == "Đang sử dụng" || phong.TrangThai == "Đang bảo trì")
                {
                    return BadRequest(new { message = $"Không thể cập nhật thiết bị trong phòng đang {phong.TrangThai.ToLower()}" });
                }

                // Map UpdateThietBi to existing ThietBi entity
                existingThietBi.TenThietBi = model.TenThietBi;
                existingThietBi.LoaiThietBi = model.LoaiThietBi;
                existingThietBi.TinhTrang = model.TinhTrang;
                existingThietBi.Gia = model.Gia;
                existingThietBi.SoLuong = model.SoLuong;
                existingThietBi.IdPhong = model.IdPhong;

                // Update the equipment
                var success = await _thietBiRepository.UpdateAsync(existingThietBi);
                if (!success)
                {
                    return StatusCode(500, new { message = "Không thể cập nhật thiết bị" });
                }

                // Get updated equipment with details
                var updatedThietBi = await _thietBiRepository.GetByIdWithDetailsAsync(id);
                if (updatedThietBi == null)
                {
                    return StatusCode(500, new { message = "Lỗi khi lấy thông tin thiết bị sau khi cập nhật" });
                }

                return Ok(new { 
                    message = "Cập nhật thiết bị thành công",
                    data = updatedThietBi
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _thietBiRepository.ExistsAsync(id))
                {
                    return NotFound(new { message = $"Không tìm thấy thiết bị với ID {id}" });
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    message = "Lỗi khi cập nhật thiết bị", 
                    error = ex.Message,
                    details = ex.InnerException?.Message 
                });
            }
        }

        // DELETE: api/ThietBi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThietBi(int id)
        {
            try
            {
                var thietBi = await _thietBiRepository.GetByIdWithDetailsAsync(id);
                if (thietBi == null)
                {
                    return NotFound(new { message = $"Không tìm thấy thiết bị với ID {id}" });
                }

                // Check if equipment has maintenance records
                var hasBaoTri = await _context.ChiTietBaoTris.AnyAsync(ct => ct.IdThietBi == id);
                if (hasBaoTri)
                {
                    return BadRequest(new { message = "Không thể xóa thiết bị đã có lịch sử bảo trì" });
                }

                var success = await _thietBiRepository.DeleteAsync(id);
                if (!success)
                {
                    return StatusCode(500, new { message = "Không thể xóa thiết bị" });
                }

                return Ok(new { 
                    message = "Xóa thiết bị thành công",
                    data = thietBi 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    message = "Lỗi khi xóa thiết bị", 
                    error = ex.Message,
                    details = ex.InnerException?.Message 
                });
            }
        }

        // PUT: api/ThietBi/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateThietBiStatus(int id, [FromBody] string tinhTrang)
        {
            try
            {
                var thietBi = await _thietBiRepository.GetByIdAsync(id);
                if (thietBi == null)
                {
                    return NotFound(new { message = $"Không tìm thấy thiết bị với ID {id}" });
                }

                if (string.IsNullOrWhiteSpace(tinhTrang))
                {
                    return BadRequest(new { message = "Tình trạng thiết bị không được để trống" });
                }

                thietBi.TinhTrang = tinhTrang;
                var success = await _thietBiRepository.UpdateAsync(thietBi);
                if (!success)
                {
                    return StatusCode(500, new { message = "Không thể cập nhật tình trạng thiết bị" });
                }

                var updatedThietBi = await _thietBiRepository.GetByIdWithDetailsAsync(id);
                return Ok(new { 
                    message = "Cập nhật tình trạng thiết bị thành công",
                    data = updatedThietBi
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    message = "Lỗi khi cập nhật tình trạng thiết bị", 
                    error = ex.Message,
                    details = ex.InnerException?.Message 
                });
            }
        }
    }
}