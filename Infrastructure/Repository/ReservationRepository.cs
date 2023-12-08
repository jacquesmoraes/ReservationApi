using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context = context;
        }

        public Task<Reservation> CreateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
           return  await _context.Reservations.ToListAsync();
        }
        
       

        public async Task<Reservation> GetReservationById(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservationByTableId(int id, DateTime date, TimeSpan? time)
        {
            var duration = new TimeSpan(5, 0, 0);
         
            var reservations = await _context.Reservations.Where(x => x.TableId == id &&
           x.ReservationDate == date).ToListAsync();
            if (time.HasValue)
            {
                var result = reservations.Where(x => x.ReservationTime <= time &&
           x.ReservationTime.Add(duration) >= time).ToList();
                return result;
            }
            else
            {
                return reservations.ToList();
            }
        }

       

        
    }

}
