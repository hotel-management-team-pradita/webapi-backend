using hotel_management_backend.Data;
using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace hotel_management_backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase 
{
    private readonly ApplicationDbContext _context;
    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetUser")]
    public async Task<ActionResult<IEnumerable<RoomModel>>> Get(int pageNumber = 1, int pageSize = 10)
    {
        var users = await _context.Users
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (users == null || !users.Any())
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<ActionResult<UserModel>> Get(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return Ok(new UserModel());
        }

        return Ok(user);
    }

    public class UserPayload
    {
        public string Fullname { get; set; }
        public GenderOptions Gender { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<ActionResult<UserModel>> Post([FromForm] UserPayload payload)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var user = new UserModel()
        {
            Fullname = payload.Fullname,
            Gender = payload.Gender,
            Password = payload.Password,
            Email = payload.Email,
            PhoneNumber = payload.PhoneNumber,
            Address = payload.Address
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetUserById", new { id = user.UserId }, user);
    }

    [HttpPut("{id}", Name = "UpdateUser")]
    public async Task<IActionResult> Put(int id, [FromBody] UserModel user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.UserId == id))
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

    [HttpDelete("{id}", Name = "DeleteUser")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}