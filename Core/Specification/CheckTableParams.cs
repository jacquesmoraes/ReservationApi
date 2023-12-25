using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class CheckTableParams
    {
        public int ReservationId { get; set; }
        public int NumberOfGuests { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReservationDate { get; set; }

        public TimeSpan ReservationTime { get; set; }
    }
}
