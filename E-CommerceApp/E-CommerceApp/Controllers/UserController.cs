
using E_CommerceApp.Models;
using E_CommerceApp.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_CommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ECommDBContext _eCommDBContext;

        public UserController(ECommDBContext eCommDBContext)
        {
            _eCommDBContext = eCommDBContext;
        }

        //GET 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _eCommDBContext.Users.ToListAsync();
            if (users == null) { return NotFound(); }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            var user = await _eCommDBContext.Users.FirstOrDefaultAsync(user => user.userID == id);
            return user;
        }


        //POST
        
        [HttpPost]
        public async Task<int> Create(User user)
        {
            _eCommDBContext.Users.Add(user);
            await _eCommDBContext.SaveChangesAsync();
            return user.userID;
        }
       

        //PUT

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, User user)
        {
            var existingUser = await _eCommDBContext.Users.FirstOrDefaultAsync(i => i.userID == id);
            existingUser = user; //might need to do it propriety one by one
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var user = await _eCommDBContext.Users.FirstOrDefaultAsync(user => user.userID == id);
            _eCommDBContext.Users.Remove(user);
            var result = await _eCommDBContext.SaveChangesAsync();
            return result > 0;
        }

    }
}
