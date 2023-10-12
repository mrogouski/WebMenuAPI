using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMenuAPI.Data.Models;
using WebMenuAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly WebMenuContext _context;

        public UserController(WebMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetUser(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var category = await _context.Users.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Users.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
