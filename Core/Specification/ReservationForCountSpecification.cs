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
        public ReservationForCountSpecification(CheckTableParams tableParams) : base(x =>
            x.Id ==  tableParams.ReservationId ||
                 x.ReservationDate == tableParams.ReservationDate ||
                 x.ReservationTime == tableParams.ReservationTime ||
                 x.NumberOfPeople == tableParams.NumberOfGuests
            
        )
        {

        }
    }
}
