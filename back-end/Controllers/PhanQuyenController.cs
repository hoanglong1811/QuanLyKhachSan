using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanQuyenController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhanQuyenController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/PhanQuyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanQuyen>>> GetPhanQuyens()
        {
            return await _context.PhanQuyens
                .Include(pq => pq.IdVaiTroNavigation)
                .ToListAsync();
        }

        // GET: api/PhanQuyen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanQuyen>> GetPhanQuyen(int id)
        {
            var phanQuyen = await _context.PhanQuyens
                .Include(pq => pq.IdVaiTroNavigation)
                .FirstOrDefaultAsync(pq => pq.IdPhanQuyen == id);

            if (phanQuyen == null)
            {
                return NotFound();
            }

            return phanQuyen;
        }

        // POST: api/PhanQuyen
        [HttpPost]
        public async Task<ActionResult<PhanQuyen>> PostPhanQuyen(PhanQuyen phanQuyen)
        {
            _context.PhanQuyens.Add(phanQuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhanQuyen), new { id = phanQuyen.IdPhanQuyen }, phanQuyen);
        }

        // PUT: api/PhanQuyen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhanQuyen(int id, PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.IdPhanQuyen)
            {
                return BadRequest();
            }

            _context.Entry(phanQuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanQuyenExists(id))
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

        // DELETE: api/PhanQuyen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhanQuyen(int id)
        {
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            _context.PhanQuyens.Remove(phanQuyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhanQuyenExists(int id)
        {
            return _context.PhanQuyens.Any(e => e.IdPhanQuyen == id);
        }
    }
}