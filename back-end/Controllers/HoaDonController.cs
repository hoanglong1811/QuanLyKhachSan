using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public HoaDonController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/HoaDon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDons()
        {
            return await _context.HoaDons.ToListAsync();
        }

        // GET: api/HoaDon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDon(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return hoaDon;
        }

        // POST: api/HoaDon
        [HttpPost]
        public async Task<ActionResult<HoaDon>> PostHoaDon(HoaDon hoaDon)
        {
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHoaDon), new { id = hoaDon.IdHoaDon }, hoaDon);
        }

        // PUT: api/HoaDon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDon(int id, HoaDon hoaDon)
        {
            if (id != hoaDon.IdHoaDon)
            {
                return BadRequest();
            }

            _context.Entry(hoaDon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonExists(id))
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

        // DELETE: api/HoaDon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDon(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.IdHoaDon == id);
        }
    }
}