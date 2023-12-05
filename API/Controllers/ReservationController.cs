using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public IActionResult getTables()
        {
            var tables =  _reservationRepository.GetTables();
            return Ok(tables);
        }
        
        [HttpPost]

        public async Task<IActionResult> ReserveTable(Reservation reservation)
        {
           
            if (await _reservationRepository.Reservation(reservation))
            {
                return Ok("table reservation succed");
            }
            return BadRequest("sorry table is not available");
        }
    }
}
