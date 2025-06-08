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
    public class HoaDonController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        private readonly IHoaDonRepository _hoaDonRepository;

        public HoaDonController(DataQlks114Nhom3Context context, IHoaDonRepository hoaDonRepository)
        {
            _hoaDonRepository = hoaDonRepository;
            _context = context;
        }

        // GET: api/HoaDon
        [HttpGet]
        public async Task<IEnumerable<HoaDonVM>> GetAllAsync()
        {
            return await _hoaDonRepository.GetAllAsync();
        }

        // GET: api/HoaDon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonVM>> GetHoaDon(int id)
        {
            var hoaDon = await _hoaDonRepository.GetByIdAsync(id);

            if (hoaDon == null)
            {
                return NotFound($"Hóa đơn với ID {id} không tồn tại.");
            }

            return hoaDon;
        }

        // POST: api/HoaDon
        [HttpPost]
        public async Task<IActionResult> PostHoaDon([FromBody] AddHoaDon entity)
        {
            var hoaDon = await _hoaDonRepository.AddAsync(entity);
           
            return Ok(new { message = "Thêm hóa đơn thành công", hoaDon }); 
        }

        // PUT: api/HoaDon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateHoaDon entity)
        {
            var result = await _hoaDonRepository.UpdateAsync(id, entity);
            if (!result)
                return NotFound($"Hóa đơn với ID {id} không tồn tại.");
            return Ok($"Đã cập nhật hóa đơn với ID {id} thành công.");
        }

        // DELETE: api/HoaDon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDon(int id)
        {
            var result = await _hoaDonRepository.DeleteAsync(id);
            if (!result)
                return NotFound($"Hóa đơn với ID {id} không tồn tại.");
            return Ok($"Đã xóa hóa đơn với ID {id} thành công.");
        }       
    }
}