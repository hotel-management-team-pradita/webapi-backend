using hotel_management_backend.Data;
using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using hotel_management_backend.Utilities;

namespace hotel_management_backend.Controllers
{
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
                return NotFound();
            }

            return Ok(roomType);
        }

        public class RoomTypeModelPayload
        {
            public IFormFile? Image { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            public List<RoomModel>? Rooms { get; set; }
        }

        // POST: /RoomTypes
        [HttpPost(Name = "CreateRoomType")]
        public async Task<ActionResult<RoomTypeModel>> Post([FromForm] RoomTypeModelPayload payload)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var roomType = new RoomTypeModel
            {
                Name = payload.Name,
                Description = payload.Description,
                Rooms = payload.Rooms
            };

            if (payload.Image != null)
            {
                var pathname = await UploadUtils.UploadImage(payload.Image);
                roomType.Image = pathname;
            }

            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetRoomTypeById", new { id = roomType.TypeId }, roomType);
        }

        // PUT: /RoomTypes/{id}
        [HttpPut("{id}", Name = "UpdateRoomType")]
        public async Task<IActionResult> Put(int id, [FromForm] RoomTypeModelPayload payload)
        {
            var roomType = await _context.RoomTypes.FirstOrDefaultAsync(x => x.TypeId == id);
            if (roomType == null)
            {
                return NotFound();
            }

            if (payload.Image != null)
            {
                var pathname = await UploadUtils.UploadImage(payload.Image);
                roomType.Image = pathname;
            }

            roomType.Name = payload.Name;
            roomType.Description = payload.Description;
            roomType.Rooms = payload.Rooms;
            _context.Entry(roomType).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(roomType);
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
}
