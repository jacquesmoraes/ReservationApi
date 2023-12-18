using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{

    public class ReservationController : BaseApiController
    {

        private readonly IGenericsRepository<Reservation> _reservation;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IGenericsRepository<Table> _table;

        public ReservationController(IGenericsRepository<Reservation> reservation, IMapper mapper,
            IGenericsRepository<Table> table, IReservationRepository reservationRepository)
        {
           _reservationRepository = reservationRepository;
           _reservation= reservation;
            _mapper = mapper;
            _table = table;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> Reservations()
        {
            var spec = new ReservationsWithTablesSpecifications();
            var reservations = await _reservation.ListAsync(spec);
            return Ok( _mapper.Map<IEnumerable<Reservation>, 
                        IEnumerable<ReservationDto>>( reservations ) );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservationsById(int id)
        {
            var spec = new ReservationsWithTablesSpecifications(id);
            var reservation = await _reservation.GetEntityWithSpec(spec);
            return _mapper.Map<Reservation, ReservationDto>(reservation);


        }
        [HttpPost]

        public async Task<ActionResult<Reservation>> CreateReservation(Reservation reservation)
        {

            bool isTableAvaiable = await _reservationRepository.IsTableAvailable(reservation.TableId, reservation.GuestName, reservation.ReservationDate, reservation.ReservationTime);
            if (!isTableAvaiable)
            {
                return BadRequest("sorry, table is not avaiable");
            }
            var createReservation = await _reservationRepository.CreateReservation(reservation);
            return CreatedAtAction(nameof(GetReservationsById), new { id = createReservation.Id }, createReservation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservationDto>> DeleteReservation(int id)
        {
            var spec = new ReservationsWithTablesSpecifications(id);
            var existingReservation = await _reservation.GetEntityWithSpec(spec);
            if (existingReservation == null)
            {
                return NotFound();
            }
            try
            {
                await _reservationRepository.DeleteReservationAsync(existingReservation);
                return Ok("reservation deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reservation>> UpdateReservation(Reservation reservation)
        {
            var existingReservation = _reservation.GetByIdAsync(reservation.Id);
            if(existingReservation == null) 
            {
                return NotFound("sorry, reservation not found");
            }

            bool isTableAvaiable = await _reservationRepository.IsTableAvailable(reservation.TableId, reservation.GuestName, reservation.ReservationDate, reservation.ReservationTime);
            if (!isTableAvaiable)
            {
                return BadRequest("sorry, table is not avaiable");
            }
            try
            {
                return await _reservationRepository.UpdateReservationAsync(reservation);
            }
            
           catch(DBConcurrencyException ex)
            {
                throw new DBConcurrencyException(ex.Message);
            }

        }

        








    }
}