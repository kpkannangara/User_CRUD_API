using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCRUDAPI.Data;
using UserCRUDAPI.Models;

namespace UserCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public UserController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDetails>>> Get()
        {
            var users = new List<UserDetails> {
            new UserDetails{UserName ="Kaveen", Password="1234", Email = "kaveen@gmail.com" }
            };
            return Ok(await dbContext.Users.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> GetById(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
                return BadRequest("user not found");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserDetails>>> AddUser(UserDetails user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return Ok(await dbContext.Users.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<UserDetails>> UpdateUser(UserDetails request)
        {
            var user = await dbContext.Users.FindAsync(request.Id);
            if (user == null)
                return BadRequest("user is not found");
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;

            await dbContext.SaveChangesAsync();
            return Ok(await dbContext.Users.FindAsync(request.Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserDetails>>> DeleteUser(int id) 
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
                return BadRequest("not user found");
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return Ok(await dbContext.Users.ToListAsync());

        }
    }
}
