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
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepository _khachHangRepository;

        public KhachHangController(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }

        // GET: api/KhachHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHangVM>>> GetKhachHangs()
        {
            try
            {
                var khachHangs = await _khachHangRepository.GetAllAsync();
                return Ok(khachHangs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/KhachHang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHangVM>> GetKhachHang(int id)
        {
            try
            {
                var khachHang = await _khachHangRepository.GetByIdAsync(id);

                if (khachHang == null)
                {
                    return NotFound(new { message = $"Khách hàng với ID {id} không tồn tại." });
                }

                return Ok(khachHang);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // GET: api/KhachHang/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<KhachHangVM>>> SearchKhachHang([FromQuery] string phone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phone))
                {
                    return BadRequest(new { message = "Số điện thoại không được để trống" });
                }

                var khachHangs = await _khachHangRepository.SearchKhachHangAsync(phone);
                return Ok(khachHangs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST: api/KhachHang
        [HttpPost]
        public async Task<ActionResult<KhachHangVM>> PostKhachHang(AddKhachHang model)
        {
            try
            {
                var khachHang = await _khachHangRepository.AddAsync(model);
                return CreatedAtAction(nameof(GetKhachHang), new { id = khachHang.IdKhachHang }, khachHang);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // PUT: api/KhachHang/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachHang(int id, UpdateKhachHang model)
        {
            try
            {
                var result = await _khachHangRepository.UpdateAsync(id, model);
                if (!result)
                {
                    return NotFound(new { message = $"Khách hàng với ID {id} không tồn tại." });
                }

                return Ok(new { message = $"Đã cập nhật khách hàng với ID {id} thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE: api/KhachHang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(int id)
        {
            try
            {
                var result = await _khachHangRepository.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new { message = $"Khách hàng với ID {id} không tồn tại." });
                }

                return Ok(new { message = $"Đã xóa khách hàng với ID {id} thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}