using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDatPhongController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietDatPhongController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/ChiTietDatPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDatPhong>>> GetChiTietDatPhongs()
        {
            return await _context.ChiTietDatPhongs
                .Include(ct => ct.IdKhachHangNavigation)
                .ToListAsync();
        }

        // GET: api/ChiTietDatPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDatPhong>> GetChiTietDatPhong(int id)
        {
            var chiTietDatPhong = await _context.ChiTietDatPhongs
                .Include(ct => ct.IdKhachHangNavigation)
                .FirstOrDefaultAsync(ct => ct.IdChiTietDatPhong == id);

            if (chiTietDatPhong == null)
            {
                return NotFound();
            }

            return chiTietDatPhong;
        }

        // POST: api/ChiTietDatPhong
        [HttpPost]
        public async Task<ActionResult<ChiTietDatPhong>> PostChiTietDatPhong(ChiTietDatPhong chiTietDatPhong)
        {
            _context.ChiTietDatPhongs.Add(chiTietDatPhong);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChiTietDatPhong), new { id = chiTietDatPhong.IdChiTietDatPhong }, chiTietDatPhong);
        }

        // PUT: api/ChiTietDatPhong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDatPhong(int id, ChiTietDatPhong chiTietDatPhong)
        {
            if (id != chiTietDatPhong.IdChiTietDatPhong)
            {
                return BadRequest();
            }

            _context.Entry(chiTietDatPhong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietDatPhongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ChiTietDatPhong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDatPhong(int id)
        {
            var chiTietDatPhong = await _context.ChiTietDatPhongs.FindAsync(id);
            if (chiTietDatPhong == null)
            {
                return NotFound();
            }

            _context.ChiTietDatPhongs.Remove(chiTietDatPhong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietDatPhongExists(int id)
        {
            return _context.ChiTietDatPhongs.Any(e => e.IdChiTietDatPhong == id);
        }
    }
}