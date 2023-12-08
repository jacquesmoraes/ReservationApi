using Core.Entities;

namespace Core.Interfaces
{
    public interface IReservationRepository
    {
       
           Task<IEnumerable<Reservation>> GetAllReservations();
            Task<Reservation> GetReservationById(int id);
       
           Task<Reservation> CreateReservation(Reservation reservation);

            Task<IEnumerable<Reservation>> GetReservationByTableId(int id,  DateTime date, TimeSpan? time);


    }
}
