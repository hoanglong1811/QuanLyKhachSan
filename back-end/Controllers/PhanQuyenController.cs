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
    public class PhanQuyenController : ControllerBase
    {
        private readonly IPhanQuyenRepository _phanQuyenRepository;

        public PhanQuyenController(IPhanQuyenRepository phanQuyenRepository)
        {
            _phanQuyenRepository = phanQuyenRepository;
        }

        // GET: api/PhanQuyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanQuyenVM>>> GetPhanQuyens()
        {
            var phanQuyens = await _phanQuyenRepository.GetAllAsync();
            return Ok(phanQuyens);
        }

        // GET: api/PhanQuyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanQuyenVM>> GetPhanQuyen(int id)
        {
            var phanQuyen = await _phanQuyenRepository.GetByIdAsync(id);

            if (phanQuyen == null)
            {
                return NotFound("Không tìm thấy phân quyền");
            }

            return Ok(phanQuyen);
        }

        // POST: api/PhanQuyen
        [HttpPost]
        public async Task<ActionResult<PhanQuyenVM>> PostPhanQuyen(AddPhanQuyen model)
        {
            var phanQuyen = await _phanQuyenRepository.AddAsync(model);
            return CreatedAtAction(nameof(GetPhanQuyen), new { id = phanQuyen.IdPhanQuyen }, phanQuyen);
        }

        // PUT: api/PhanQuyen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhanQuyen(int id, UpdatePhanQuyen model)
        {
            var result = await _phanQuyenRepository.UpdateAsync(id, model);
            if (!result)
            {
                return NotFound("Không tìm thấy phân quyền");
            }

            return Ok("Cập nhật phân quyền thành công");
        }

        // DELETE: api/PhanQuyen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanQuyen(int id)
        {
            var result = await _phanQuyenRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Không tìm thấy phân quyền");
            }

            return Ok("Xóa phân quyền thành công");
        }
        
    }
}