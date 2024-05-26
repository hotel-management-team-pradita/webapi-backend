using hotel_management_backend.Data;
using hotel_management_backend.Models;
using hotel_management_backend.Utilities;
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

    // GET: /Room/{id}
    [HttpGet("{id}", Name = "GetRoomById")]
    public async Task<ActionResult<RoomModel>> Get(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    public class RoomModelPayload
    {
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatus Status { get; set; }
        public RoomTypeModel? RoomType { get; set; }
    }

    // POST: /Room
    [HttpPost(Name = "CreateRoom")]
    public async Task<ActionResult<RoomModel>> Post([FromForm] RoomModelPayload payload)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var room = new RoomModel
        {
            Name = payload.Name,
            Description = payload.Description,
            Quantity = payload.Quantity,
            Price = payload.Price,
            Status = payload.Status,
            RoomTypeId = payload.RoomTypeId,
        };

        if (payload.Image != null)
        {
            var pathname = await UploadUtils.UploadImage(payload.Image);
            room.Image = pathname;
        }

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetRoomById", new { id = room.RoomTypeId }, room);
    }

    // PUT: /Room/{id}
    [HttpPut("{id}", Name = "UpdateRoom")]
    public async Task<IActionResult> Put(int id, [FromForm] RoomModelPayload payload)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
        if (room == null)
        {
            return NotFound();
        }

        if (payload.Image != null)
        {
            var pathname = await UploadUtils.UploadImage(payload.Image);
            room.Image = pathname;
        }

        room.Name = payload.Name;
        room.Description = payload.Description;
        room.Quantity = payload.Quantity;
        room.Price = payload.Price;
        room.Status = payload.Status;
        room.RoomType = payload.RoomType;
        _context.Entry(room).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Ok(room);
    }

    // DELETE: /Room/{id}
    [HttpDelete("{id}", Name = "DeleteRoom")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
