using Core.Entities;

namespace Core.Interfaces
{
    public interface IReservationRepository
    {
       
           Task<IEnumerable<Reservation>> GetAllReservations();
            Task<IEnumerable<Reservation>> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetReservationByTableId(int tableId);
           Task<Reservation> CreateReservation(Reservation reservation);

            Task<Reservation> GetReservationByDateAndTime(int id,  DateTime date, TimeSpan time);


    }
}
