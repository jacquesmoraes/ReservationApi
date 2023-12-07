using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Reservation : BaseEntity
    {

        public string GuestName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        
       public TimeSpan ReservationTime { get; set; }
        public int NumberOfPeople { get; set; }

        public int TableId { get; set; }
        public virtual Table Table { get; set; }


        


    }
}