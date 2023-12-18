using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ReservationParams
    {
        public int ReservationId { get; set; }
        public int NumberOfGuests { get; set; }

        public DateTime ReservationDate { get; set; }

        public TimeSpan ReservationTime { get; set; }
    }
}
