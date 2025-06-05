using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public DatPhongController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/DatPhong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatPhong>>> GetDatPhongs()
        {
            return await _context.DatPhongs
                .Include(dp => dp.IdKhachHangNavigation)
                .ToListAsync();
        }

        // GET: api/DatPhong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatPhong>> GetDatPhong(int id)
        {
            var datPhong = await _context.DatPhongs
                .Include(dp => dp.IdKhachHangNavigation)
                .FirstOrDefaultAsync(dp => dp.IdDatPhong == id);

            if (datPhong == null)
            {
                return NotFound();
            }

            return datPhong;
        }

        // POST: api/DatPhong
        [HttpPost]
        public async Task<ActionResult<DatPhong>> PostDatPhong(DatPhong datPhong)
        {
            _context.DatPhongs.Add(datPhong);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDatPhong), new { id = datPhong.IdDatPhong }, datPhong);
        }

        // PUT: api/DatPhong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatPhong(int id, DatPhong datPhong)
        {
            if (id != datPhong.IdDatPhong)
            {
                return BadRequest();
            }

            _context.Entry(datPhong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatPhongExists(id))
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

        // DELETE: api/DatPhong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatPhong(int id)
        {
            var datPhong = await _context.DatPhongs.FindAsync(id);
            if (datPhong == null)
            {
                return NotFound();
            }

            _context.DatPhongs.Remove(datPhong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatPhongExists(int id)
        {
            return _context.DatPhongs.Any(e => e.IdDatPhong == id);
        }
    }
}