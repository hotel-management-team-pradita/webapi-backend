using hotel_management_backend.Data;
using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.ObjectPool;


namespace hotel_management_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomTypeController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public RoomTypeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /RoomTypes
    [HttpGet(Name = "GetRoomTypes")]
    public async Task<ActionResult<IEnumerable<RoomTypeModel>>> Get()
    {
        var roomTypes = await _context.RoomTypes.ToListAsync();

        if (roomTypes == null || !roomTypes.Any())
        {
            return Ok(new List<RoomTypeModel>());
        }

        return Ok(roomTypes);
    }

    // GET: /RoomTypes/{id}
    [HttpGet("{id}", Name = "GetRoomTypeById")]
    public async Task<ActionResult<RoomTypeModel>> Get(int id)
    {
        var roomType = await _context.RoomTypes.FindAsync(id);

        if (roomType == null)
        {
            return Ok(new RoomTypeModel());
        }

        return Ok(roomType);
    }


    public class RoomTypePostPayload
    {
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<RoomModel>? Rooms { get; set; }
    }
    /// POST: /RoomTypes
    [HttpPost(Name = "CreateRoomType")]
    public async Task<ActionResult<RoomTypeModel>> Post([FromForm] RoomTypePostPayload payload)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var roomType = new RoomTypeModel()
        {
            Name = payload.Name,
            Description = payload.Description,
            Rooms = payload.Rooms,
        };



        // Handle file upload
        if (payload.Image != null)
        {
            var file = payload.Image;
            if (file != null && file.Length > 0)
            {
                // Combine the path to include the current directory
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                // Ensure the uploads directory exists
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Save the file path
                roomType.Image = filePath;
            }

        }

        _context.RoomTypes.Add(roomType);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetRoomTypeById", new { id = roomType.TypeId }, roomType);
    }

    // PUT: /RoomTypes/{id}
    [HttpPut("{id}", Name = "UpdateRoomType")]
    public async Task<IActionResult> Put(int id, [FromBody] RoomTypeModel roomType)
    {
        if (id != roomType.TypeId)
        {
            return BadRequest();
        }

        _context.Entry(roomType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.RoomTypes.Any(e => e.TypeId == id))
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

    // DELETE: /RoomTypes/{id}
    [HttpDelete("{id}", Name = "DeleteRoomType")]
    public async Task<IActionResult> Delete(int id)
    {
        var roomType = await _context.RoomTypes.FindAsync(id);
        if (roomType == null)
        {
            return NotFound();
        }

        _context.RoomTypes.Remove(roomType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
