using hotel_management_backend.Data;
using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace hotel_management_backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    public class AuthPayload 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [HttpPost(Name = "Authentication")]
    public async Task<ActionResult<UserModel>> Post([FromForm] AuthPayload payload)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var requestPayload = new UserModel()
        {
            Email = payload.Email,
            Password = payload.Password,
        };

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == payload.Email);

        if (user == null || user.Password != payload.Password)
        {
            return NotFound();
        }

        return Ok(user);
    }
}