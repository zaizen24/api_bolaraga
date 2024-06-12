using bolaraga_api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace bolaraga_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
        {
            return await _context.Admin.ToListAsync();
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admin.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var admin = await _context.Admin.SingleOrDefaultAsync(a => a.username == request.Username);
            if (admin == null)
            {
                return NotFound("Admin not found.");
            }

            if (admin.password != request.OldPassword)
            {
                return BadRequest("Old password is incorrect.");
            }

            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return BadRequest("New password and confirmation password do not match.");
            }

            admin.password = request.NewPassword;
            await _context.SaveChangesAsync();

            return Ok("Password has been changed successfully.");
        }

        public class ChangePasswordRequest
        {
            public string Username { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmNewPassword { get; set; }
        }
    }
}
