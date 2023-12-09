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

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationsById(int id)
        {
            return await _reservationRepository.GetReservationById(id);
        }

        [HttpGet("available")]
        public async Task<IEnumerable<Reservation>> GetReservationsByTable( int id,  DateTime date, TimeSpan? time)
        {
            return await _reservationRepository.GetReservationByTableId(id, date, time);
        }



        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation(Reservation reservation)
        {
           
                bool isTableAvaiable = await _reservationRepository.IsTableAvailable(reservation.TableId,reservation.GuestName, reservation.ReservationDate, reservation.ReservationTime);
                if (!isTableAvaiable) 
                {
                    return BadRequest("sorry, table is not avaiable");
                }
               var createReservation = await _reservationRepository.CreateReservation(reservation);
                return CreatedAtAction(nameof(GetReservationsById),new {id = createReservation.Id }, createReservation);
            }
           
        }




    }

