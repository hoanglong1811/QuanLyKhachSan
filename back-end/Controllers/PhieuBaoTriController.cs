using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuBaoTriController : ControllerBase
    {
        private readonly DataQlks114Nhom3Context _context;

        public PhieuBaoTriController(DataQlks114Nhom3Context context)
        {
            _context = context;
        }

        // GET: api/PhieuBaoTri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuBaoTri>>> GetPhieuBaoTris()
        {
            return await _context.PhieuBaoTris
                .Include(p => p.ChiTietBaoTris)
                .ToListAsync();
        }

        // GET: api/PhieuBaoTri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuBaoTri>> GetPhieuBaoTri(int id)
        {
            var phieuBaoTri = await _context.PhieuBaoTris
                .Include(p => p.ChiTietBaoTris)
                .FirstOrDefaultAsync(p => p.IdPhieuBaoTri == id);

            if (phieuBaoTri == null)
            {
                return NotFound();
            }

            return phieuBaoTri;
        }

        // POST: api/PhieuBaoTri
        [HttpPost]
        public async Task<ActionResult<PhieuBaoTri>> PostPhieuBaoTri(PhieuBaoTri phieuBaoTri)
        {
            _context.PhieuBaoTris.Add(phieuBaoTri);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhieuBaoTri), new { id = phieuBaoTri.IdPhieuBaoTri }, phieuBaoTri);
        }

        // PUT: api/PhieuBaoTri/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuBaoTri(int id, PhieuBaoTri phieuBaoTri)
        {
            if (id != phieuBaoTri.IdPhieuBaoTri)
            {
                return BadRequest();
            }

            _context.Entry(phieuBaoTri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuBaoTriExists(id))
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

        // DELETE: api/PhieuBaoTri/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieuBaoTri(int id)
        {
            var phieuBaoTri = await _context.PhieuBaoTris.FindAsync(id);
            if (phieuBaoTri == null)
            {
                return NotFound();
            }

            _context.PhieuBaoTris.Remove(phieuBaoTri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhieuBaoTriExists(int id)
        {
            return _context.PhieuBaoTris.Any(e => e.IdPhieuBaoTri == id);
        }
    }
}