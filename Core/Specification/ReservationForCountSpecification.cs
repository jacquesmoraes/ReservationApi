using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ReservationForCountSpecification : BaseSpecification<Reservation>
    {
        public ReservationForCountSpecification(ReservationParams reservationParams) : base(x =>
            x.Id == reservationParams.ReservationId ||
                 x.ReservationDate == reservationParams.ReservationDate ||
                 x.ReservationTime == reservationParams.ReservationTime ||
                 x.NumberOfPeople == reservationParams.NumberOfGuests
            
        )
        {

        }
    }
}
