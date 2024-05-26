using hotel_management_backend.Data;
using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace hotel_management_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public RoomController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetRoom")]
    public async Task<ActionResult<IEnumerable<RoomModel>>> Get(int pageNumber = 1, int pageSize = 10)
    {
        var rooms = await _context.Rooms
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (rooms == null || !rooms.Any())
        {
            return NotFound();
        }

        return Ok(rooms);
    }

}
