using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class ReservationController : BaseApiController
    {
        
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ReservationDto>> Reservations()
        {
            var reservations = await _reservationRepository.GetAllReservations();
            var data = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationDto>>(reservations);
            return Ok( data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservationsById(int id)
        {
            var reservation = await  _reservationRepository.GetReservationById(id);
            return _mapper.Map<Reservation, ReservationDto>(reservation);

            
        }

        [HttpGet("available")]
        public async Task<IEnumerable<Reservation>> GetReservationsByTable( int id,  DateTime date, TimeSpan? time)
        {
            return  await _reservationRepository.GetReservationByTableId(id, date, time);
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

