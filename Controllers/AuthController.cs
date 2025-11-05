using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Data;    
using MovieRentalAPI.Models;  

namespace MovieRentalAPI.Controllers  
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == login.EmailAddress && u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new { 
                message = "Login successful", 
                user = new { user.UserId, user.FullName, user.EmailAddress } 
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == user.EmailAddress);

            if (existingUser != null)
            {
                return BadRequest("User with this email already exists");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }
    }
}