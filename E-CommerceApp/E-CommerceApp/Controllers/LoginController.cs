using E_CommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ECommDBContext _eCommDBContext;

        public LoginController(ECommDBContext eCommDBContext)
        {
            _eCommDBContext = eCommDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _eCommDBContext.Users.FirstOrDefaultAsync(u => u.email == model.Email && u.password == model.Password);

            if (user == null)
            {
                return NotFound("Invalid email or password");
            }

            // Authentication successful, you can generate a JWT token or return user information
            // For example, return user.Id or user.Email

            return Ok("Authentication successful");
        }
    }
}
