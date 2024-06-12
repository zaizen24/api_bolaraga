using bolaraga_api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace bolaraga_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapanganController : Controller
    {
        private readonly AppDbContext _context;

        public LapanganController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Lapangan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lapangan>>> GetLapangan()
        {
            return await _context.Lapangan.ToListAsync();
        }

        // GET: api/Lapangan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lapangan>> GetLapangan(int id)
        {
            var lapangan = await _context.Lapangan.FindAsync(id);

            if (lapangan == null)
            {
                return NotFound();
            }

            return lapangan;
        }

        // POST: api/Lapangan
        [HttpPost]
        public async Task<ActionResult<Lapangan>> PostLapangan([FromBody] Lapangan lapangan)
        {
            _context.Lapangan.Add(lapangan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLapangan", new { id = lapangan.id_lap }, lapangan);
        }
        
        [HttpPut]
        public async Task<IActionResult> PutLapangan([FromBody] Lapangan lapangan)
        {
            if (!LapanganExists(lapangan.id_lap))
            {
                return NotFound();
            }

            _context.Entry(lapangan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LapanganExists(lapangan.id_lap))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLapangan(int id)
        {
            var lapangan = await _context.Lapangan.FindAsync(id);
            if (lapangan == null)
            {
                return NotFound();
            }

            _context.Lapangan.Remove(lapangan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LapanganExists(int id)
        {
            return _context.Lapangan.Any(e => e.id_lap == id);
        }
    }
}
