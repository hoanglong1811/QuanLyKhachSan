using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhongController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/Phong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phong>>> GetPhongs()
        {
            return await _context.Phongs
                .Include(p => p.IdLoaiPhongNavigation)
                .Include(p => p.ThietBis)
                .ToListAsync();
        }

        // GET: api/Phong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phong>> GetPhong(int id)
        {
            var phong = await _context.Phongs
                .Include(p => p.IdLoaiPhongNavigation)
                .Include(p => p.ThietBis)
                .FirstOrDefaultAsync(p => p.IdPhong == id);

            if (phong == null)
            {
                return NotFound();
            }

            return phong;
        }

        // POST: api/Phong
        [HttpPost]
        public async Task<ActionResult<Phong>> PostPhong(Phong phong)
        {
            _context.Phongs.Add(phong);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhong), new { id = phong.IdPhong }, phong);
        }

        // PUT: api/Phong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhong(int id, Phong phong)
        {
            if (id != phong.IdPhong)
            {
                return BadRequest();
            }

            _context.Entry(phong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongExists(id))
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

        // DELETE: api/Phong/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhong(int id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            _context.Phongs.Remove(phong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhongExists(int id)
        {
            return _context.Phongs.Any(e => e.IdPhong == id);
        }
    }
}