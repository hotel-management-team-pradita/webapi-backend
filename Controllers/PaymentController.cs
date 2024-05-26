using hotel_management_backend.Data;
using hotel_management_backend.Models;
using hotel_management_backend.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace hotel_management_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetPayment")]
        public async Task<ActionResult<IEnumerable<PaymentModel>>> Get()
        {
            var payment = await _context.Payments.ToListAsync();
            if (payment == null || !payment.Any())
            {
                return Ok(new List<RoomTypeModel>());
            }

            return Ok(payment);
        }

        // GET: /Room/{id}
        [HttpGet("{id}", Name = "GetPaymentById")]
        public async Task<ActionResult<RoomModel>> Get(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        public class PaymentModelPayload
        {
            public int ReservationId { get; set; }
            public int Discount { get; set; }
            // public int TotalPrice { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // POST: /Room
        [HttpPost(Name = "CreatePayment")]
        public async Task<ActionResult<RoomModel>> Post([FromForm] PaymentModelPayload payload)
        {
            if (payload == null)
            {
                return BadRequest("Payload cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var reservation = await _context.Reservations.FirstAsync(r => r.ReservationId == payload.ReservationId);

            if (reservation == null)
            {
                return BadRequest("Reservation cannot be invalid");
            }

            var TotalPrice = reservation.TotalPrice - (reservation.TotalPrice * payload.Discount);

            var payment = new PaymentModel()
            {
                Discount = payload.Discount,
                TotalPrice = Decimal.Parse(TotalPrice.ToString()),
                PaymentDate = payload.PaymentDate,
                Reservation = reservation,
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetPaymentById", new { id = payment.PaymentId }, payment);
        }
    }
}