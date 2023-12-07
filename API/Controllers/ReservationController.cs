using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class ReservationController : BaseApiController
    {
        
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Reservations()
        {
            var reservations = await _reservationRepository.GetAllReservations();
            return Ok(reservations);
        }

        [HttpGet("available")]
        public async Task<IEnumerable<Reservation>> GetReservationsByTable(int id)
        {
            return await _reservationRepository.GetReservationByTableId(id);
        }

        //[HttpPost]
        //public ActionResult<Reservation> CreateReservation([FromBody] Reservation reservation)
        //{
        //    if (reservation == null)
        //    {
        //        return BadRequest();
        //    }

        //    var createdReservation = _reservationRepository.CreateReservation(reservation);

        //    return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
        //}

        [HttpGet("{id}/tableAvailability")]
        public async Task<Reservation> GetTableAvailable(int id,DateTime date, TimeSpan time)
        {
            return await _reservationRepository.GetReservationByDateAndTime(id, date, time);
        }



    }
}
