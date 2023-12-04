using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationDbContext _context;

        public ReservationController(ReservationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getTables()
        {
            var tables =  _context.Reservations.ToList();
            return Ok(tables);
        }
        
        [HttpPost]

        public IActionResult ReserveTable([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Invalid reservation data");
            }
            var reservationTable = _context.Tables.SingleOrDefault(x => x.Id == reservation.Id && !x.IsBooked);
            if (reservationTable != null)
            {
                reservationTable.IsBooked = true;
                _context.Add(reservationTable);
                _context.SaveChanges();
                return Ok("reservation sucessfull");

            }
            return BadRequest("sorry, table is already taken");
        }
    }
}
