using Core.Entities;

namespace Core.Interfaces
{
    public interface IReservationRepository
    {
       
           
            
            Task<bool> IsTableAvailable(int id,string guestName, DateTime date, TimeSpan time);
           Task<Reservation> CreateReservation(Reservation reservation);

            Task<Reservation>  UpdateReservationAsync(Reservation reservation);

            Task<Reservation> DeleteReservationAsync(Reservation reservation);

    }
}
