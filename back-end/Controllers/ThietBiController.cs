using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThietBiController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public ThietBiController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/ThietBi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThietBi>>> GetThietBis()
        {
            return await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .ToListAsync();
        }

        // GET: api/ThietBi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThietBi>> GetThietBi(int id)
        {
            var thietBi = await _context.ThietBis
                .Include(tb => tb.IdPhongNavigation)
                .FirstOrDefaultAsync(tb => tb.IdThietBi == id);

            if (thietBi == null)
            {
                return NotFound();
            }

            return thietBi;
        }

        // POST: api/ThietBi
        [HttpPost]
        public async Task<ActionResult<ThietBi>> PostThietBi(ThietBi thietBi)
        {
            _context.ThietBis.Add(thietBi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetThietBi), new { id = thietBi.IdThietBi }, thietBi);
        }

        // PUT: api/ThietBi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThietBi(int id, ThietBi thietBi)
        {
            if (id != thietBi.IdThietBi)
            {
                return BadRequest();
            }

            _context.Entry(thietBi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThietBiExists(id))
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

        // DELETE: api/ThietBi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThietBi(int id)
        {
            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi == null)
            {
                return NotFound();
            }

            _context.ThietBis.Remove(thietBi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThietBiExists(int id)
        {
            return _context.ThietBis.Any(e => e.IdThietBi == id);
        }
    }
}