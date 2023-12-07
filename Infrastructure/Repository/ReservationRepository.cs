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
        
        public async Task<Reservation> GetReservationByDateAndTime(int tableId, DateTime date, TimeSpan time)
        {
            var duration = new TimeSpan(5, 0, 0);
            var endTime = time.Add(duration);
            return await _context.Reservations.FirstOrDefaultAsync(r =>
            r.TableId == tableId &&
             r.ReservationDate.Date == date.Date &&
             r.ReservationTime >= time );
            
           
        }

        public Task<IEnumerable<Reservation>> GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> GetReservationByTableId(int id)
        {
            var reservations =  _context.Reservations.Where(x => x.TableId == id);
           
            foreach(var reservation in reservations)
            {
                return reservations;
            }
            return reservations;
        }

       

        
    }

}
