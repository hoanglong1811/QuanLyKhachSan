using Microsoft.AspNetCore.Mvc;
using back_end.Data;
using back_end.ViewModels;
using back_end.Services;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaiTroController : ControllerBase
    {
        private readonly IVaiTroRepository _vaiTroRepository;
        private readonly IPhanQuyenRepository _phanQuyenRepository;

        public VaiTroController(IVaiTroRepository vaiTroRepository, IPhanQuyenRepository phanQuyenRepository)
        {
            _vaiTroRepository = vaiTroRepository;
            _phanQuyenRepository = phanQuyenRepository;
        }

        // GET: api/VaiTro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaiTroVM>>> GetVaiTros()
        {
            var vaiTros = await _vaiTroRepository.GetAllAsync();
            var result = vaiTros.Select(vt => new VaiTroVM
            {
                IdVaiTro = vt.IdVaiTro,
                TenVaiTro = vt.TenVaiTro ?? string.Empty,
                MoTa = vt.MoTa
            }).ToList();

            return Ok(result);
        }

        // GET: api/VaiTro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaiTroVM>> GetVaiTro(int id)
        {
            var vaiTro = await _vaiTroRepository.GetByIdAsync(id);
            if (vaiTro == null)
            {
                return NotFound($"Không tìm thấy vai trò với ID: {id}");
            }

            var result = new VaiTroVM
            {
                IdVaiTro = vaiTro.IdVaiTro,
                TenVaiTro = vaiTro.TenVaiTro ?? string.Empty,
                MoTa = vaiTro.MoTa
            };

            return Ok(result);
        }

        // GET: api/VaiTro/PhanQuyen/{idVaiTro}
        [HttpGet("PhanQuyen/{idVaiTro}")]
        public async Task<ActionResult<IEnumerable<PhanQuyenVM>>> GetPhanQuyenByVaiTro(int idVaiTro)
        {
            var phanQuyens = await _phanQuyenRepository.GetPhanQuyenByVaiTroIdAsync(idVaiTro);
            if (phanQuyens == null || !phanQuyens.Any())
            {
                return NotFound($"Không tìm thấy quyền nào cho vai trò với ID: {idVaiTro}");
            }

            var result = phanQuyens.Select(pq => new PhanQuyenVM
            {
                IdPhanQuyen = pq.IdPhanQuyen,
                IdVaiTro = pq.IdVaiTro,
                TenQuyen = pq.TenQuyen ?? string.Empty,
                QuyenHan = pq.QuyenHan,
                TenVaiTro = pq.IdVaiTroNavigation?.TenVaiTro ?? string.Empty
            }).ToList();

            return Ok(result);
        }


       


        // POST: api/VaiTro
        [HttpPost]
        public async Task<ActionResult<VaiTroVM>> PostVaiTro(AddVaiTro model)
        {
            if (string.IsNullOrEmpty(model.TenVaiTro))
            {
                return BadRequest("Tên vai trò không được để trống");
            }

            var vaiTro = new VaiTro
            {
                TenVaiTro = model.TenVaiTro,
                MoTa = model.MoTa
            };

            var newVaiTro = await _vaiTroRepository.AddAsync(vaiTro);
            var result = new VaiTroVM
            {
                IdVaiTro = newVaiTro.IdVaiTro,
                TenVaiTro = newVaiTro.TenVaiTro ?? string.Empty,
                MoTa = newVaiTro.MoTa
            };

            return CreatedAtAction(nameof(GetVaiTro), new { id = result.IdVaiTro }, result);
        }

        // PUT: api/VaiTro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaiTro(int id, UpdateVaiTro model)
        {
            

            if (string.IsNullOrEmpty(model.TenVaiTro))
            {
                return BadRequest("Tên vai trò không được để trống");
            }

            var vaiTro = new VaiTro
            {
                IdVaiTro = id,
                TenVaiTro = model.TenVaiTro,
                MoTa = model.MoTa
            };

            var success = await _vaiTroRepository.UpdateAsync(vaiTro);
            if (!success)
            {
                return NotFound($"Không tìm thấy vai trò với ID: {id}");
            }

            return Ok($"Cập nhật vai trò thành công");
        }

        // DELETE: api/VaiTro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaiTro(int id)
        {
            var success = await _vaiTroRepository.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"Không tìm thấy vai trò với ID: {id}");
            }

            return Ok($"Xóa vai trò thành công");
        }
    }
}