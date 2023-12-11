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

        

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
           return  await _context.Reservations.Include(x => x.Table).
                OrderBy(x => x.ReservationDate).ThenBy(x => x.ReservationTime).ToListAsync();
        }
        
       

        public async Task<Reservation> GetReservationById(int id)
        {
            var reservation = await _context.Reservations.Include(x => x.Table).FirstOrDefaultAsync(r => r.Id == id);
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservationByTableId(int id, DateTime date, TimeSpan? time)
        {
               
            var reservations = await _context.Reservations.Where(x => x.TableId == id &&
           x.ReservationDate == date).ToListAsync();
            if (time.HasValue)
            {
                return FilterByTime(reservations, time.Value);
            }
            else
            {
                return reservations.ToList();
            }
        }

        public async Task<bool> IsTableAvailable(int id, string name, DateTime date, TimeSpan time)
        {
            var fiveHours = TimeSpan.FromHours(5);

            var reservations = await _context.Reservations
                .Where(x => x.TableId == id && x.ReservationDate == date.Date)
                .ToListAsync();

            var isTableAvailable = reservations
                .FirstOrDefault(x =>
                    x.ReservationTime <= time && time < x.ReservationTime.Add(fiveHours) ||
                    time >= x.ReservationTime.Subtract(fiveHours) && time < x.ReservationTime);

            return isTableAvailable == null;
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        private static IEnumerable<Reservation> FilterByTime(IEnumerable<Reservation> reservations, TimeSpan time)
        {
            
                return reservations.AsEnumerable().Where(x =>
                    x.ReservationTime <= time && time < x.ReservationTime.Add(TimeSpan.FromHours(5)) ||
                time >= x.ReservationTime.Subtract(TimeSpan.FromHours(5)) && time < x.ReservationTime).AsQueryable();
            
            
        }
    }

}
