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
    [ApiController]
    [Route("api/[controller]")]
    public class ChiTietHoaDonController : ControllerBase
    {
        private readonly IChiTietHoaDonRepository _repository;

        public ChiTietHoaDonController(IChiTietHoaDonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddChiTietHoaDon model)
        {
            await _repository.AddAsync(model);
            return Ok(new { message = "Thêm chi tiết hóa đơn thành công" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateChiTietHoaDon model)
        {
            if (id != model.IdChiTietHoaDon)
                return BadRequest("Id không khớp");

            await _repository.UpdateAsync(model);
            return Ok(new { message = "Cập nhật chi tiết hóa đơn thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(new { message = "Xóa chi tiết hóa đơn thành công" });
        }
    }
}