using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bolaraga_api.models;
using System.Linq;
using System.Threading.Tasks;

namespace bolaraga_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisController : Controller
    {
        private readonly AppDbContext _context;

        public JenisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Jenis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jenis>>> GetJenis()
        {
            return await _context.Jenis.ToListAsync();
        }

        // GET: api/Jenis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jenis>> GetJenis(int id)
        {
            var jenis = await _context.Jenis.FindAsync(id);

            if (jenis == null)
            {
                return NotFound();
            }

            return jenis;
        }
    }
}
