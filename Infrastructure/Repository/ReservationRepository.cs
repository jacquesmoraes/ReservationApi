using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            bool hasAny = await _context.Reservations.AnyAsync(x => x.Id== reservation.Id);

            if (!hasAny) 
            {
                throw new Exception("Id not found"); 
            
            }
            var existingReservation = await _context.Reservations.FindAsync(reservation.Id);
            
            try
            {
                existingReservation.GuestName = reservation.GuestName;
                existingReservation.ReservationDate = reservation.ReservationDate;
                existingReservation.ReservationTime = reservation.ReservationTime;
                existingReservation.NumberOfPeople= reservation.NumberOfPeople;
                existingReservation.TableId= reservation.TableId;
                _context.Update(existingReservation);
                await _context.SaveChangesAsync();
                return existingReservation;
            }
            catch (DBConcurrencyException ex)
            {
                throw new DBConcurrencyException(ex.Message, ex);
            }
          

        }

        public async Task<Reservation> DeleteReservationAsync(Reservation reservation)
        {
            var existingReservation = await _context.Reservations.FindAsync(reservation.Id);
            if (existingReservation == null || existingReservation.Id == 0)
            {
                throw new Exception("id not provided");
            }
            try
            {
                 _context.Reservations.Remove(existingReservation);
                await _context.SaveChangesAsync();
                return reservation;
            }
            catch(DBConcurrencyException ex)
            {
                throw new DBConcurrencyException($"{ex.Message}", ex);
            }
        }
    }

}
