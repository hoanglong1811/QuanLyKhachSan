using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDichVuController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietDichVuController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/ChiTietDichVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDichVu>>> GetChiTietDichVus()
        {
            return await _context.ChiTietDichVus
                .Include(ct => ct.IdDichVuNavigation)
                .ToListAsync();
        }

        // GET: api/ChiTietDichVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDichVu>> GetChiTietDichVu(int id)
        {
            var chiTietDichVu = await _context.ChiTietDichVus
                .Include(ct => ct.IdDichVuNavigation)
                .FirstOrDefaultAsync(ct => ct.IdChiTietDichVu == id);

            if (chiTietDichVu == null)
            {
                return NotFound();
            }

            return chiTietDichVu;
        }

        // POST: api/ChiTietDichVu
        [HttpPost]
        public async Task<ActionResult<ChiTietDichVu>> PostChiTietDichVu(ChiTietDichVu chiTietDichVu)
        {
            _context.ChiTietDichVus.Add(chiTietDichVu);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChiTietDichVu), new { id = chiTietDichVu.IdChiTietDichVu }, chiTietDichVu);
        }

        // PUT: api/ChiTietDichVu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDichVu(int id, ChiTietDichVu chiTietDichVu)
        {
            if (id != chiTietDichVu.IdChiTietDichVu)
            {
                return BadRequest();
            }

            _context.Entry(chiTietDichVu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietDichVuExists(id))
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

        // DELETE: api/ChiTietDichVu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDichVu(int id)
        {
            var chiTietDichVu = await _context.ChiTietDichVus.FindAsync(id);
            if (chiTietDichVu == null)
            {
                return NotFound();
            }

            _context.ChiTietDichVus.Remove(chiTietDichVu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietDichVuExists(int id)
        {
            return _context.ChiTietDichVus.Any(e => e.IdChiTietDichVu == id);
        }
    }
}