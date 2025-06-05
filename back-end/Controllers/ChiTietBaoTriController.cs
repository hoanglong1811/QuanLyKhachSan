using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietBaoTriController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public ChiTietBaoTriController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/ChiTietBaoTri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietBaoTri>>> GetChiTietBaoTris()
        {
            return await _context.ChiTietBaoTris
                .Include(x => x.IdPhieuBaoTriNavigation)
                .Include(x => x.IdThietBiNavigation)
                .ToListAsync();
        }

        // GET: api/ChiTietBaoTri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietBaoTri>> GetChiTietBaoTri(int id)
        {
            var chiTiet = await _context.ChiTietBaoTris
                .Include(x => x.IdPhieuBaoTriNavigation)
                .Include(x => x.IdThietBiNavigation)
                .FirstOrDefaultAsync(x => x.IdChiTietBaoTri == id);

            if (chiTiet == null)
            {
                return NotFound();
            }

            return chiTiet;
        }

        // POST: api/ChiTietBaoTri
        [HttpPost]
        public async Task<ActionResult<ChiTietBaoTri>> PostChiTietBaoTri(ChiTietBaoTri chiTietBaoTri)
        {
            _context.ChiTietBaoTris.Add(chiTietBaoTri);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChiTietBaoTri), new { id = chiTietBaoTri.IdChiTietBaoTri }, chiTietBaoTri);
        }

        // PUT: api/ChiTietBaoTri/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietBaoTri(int id, ChiTietBaoTri chiTietBaoTri)
        {
            if (id != chiTietBaoTri.IdChiTietBaoTri)
            {
                return BadRequest();
            }

            _context.Entry(chiTietBaoTri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietBaoTriExists(id))
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

        // DELETE: api/ChiTietBaoTri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietBaoTri(int id)
        {
            var chiTietBaoTri = await _context.ChiTietBaoTris.FindAsync(id);
            if (chiTietBaoTri == null)
            {
                return NotFound();
            }

            _context.ChiTietBaoTris.Remove(chiTietBaoTri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietBaoTriExists(int id)
        {
            return _context.ChiTietBaoTris.Any(e => e.IdChiTietBaoTri == id);
        }
    }
}