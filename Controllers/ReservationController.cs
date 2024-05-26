using hotel_management_backend.Data;
using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace hotel_management_backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ReservationController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ReservationController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetReservation")]
    public async Task<ActionResult<IEnumerable<ReservationModel>>> Get(int pageNumber = 1, int pageSize = 10)
    {
        var reservations = await _context.Reservations
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (reservations == null || !reservations.Any())
        {
            return NotFound();
        }

        return Ok(reservations);
    }

    [HttpGet("{id}", Name = "GetReservationById")]
    public async Task<ActionResult<ReservationModel>> Get(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);

        if (reservation == null)
        {
            return Ok(new ReservationModel());
        }

        return Ok(reservation);
    }

    public class ReservationPayload 
    {
        public int UserId { get; set; }
        public int RoomId { get; set;}
        public double TotalPrice { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set;}
    }

    [HttpPost(Name = "CreateReservation")]
    public async Task<ActionResult<UserModel>> Post([FromForm] ReservationPayload payload)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var reservation = new ReservationModel()
        {
            UserId = payload.UserId,
            RoomId = payload.RoomId,
            TotalPrice = payload.TotalPrice,
            StartDate = payload.StartDate,
            EndDate = payload.EndDate,
            Status = 0
        };

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetUserById", new { id = reservation.ReservationId }, reservation);
    }

    public class UpdateReservationPayload 
    {
        public ReservationStatus Status { get; set; }
    }

    [HttpPut("{id}", Name = "UpdateReservation")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateReservationPayload payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        reservation.Status = payload.Status;

        _context.Entry(reservation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reservations.Any(e => e.ReservationId == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(reservation);
    }

    [HttpDelete("{id}", Name = "DeleteReservation")]
    public async Task<IActionResult> Delete(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();

        return Ok();
    }
}