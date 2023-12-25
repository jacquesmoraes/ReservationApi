using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Reservation : BaseEntity
    {

        [Required]
        public string GuestName { get; set; }

        [Required]

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
       public TimeSpan ReservationTime { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        public int TableId { get; set; }
        public virtual Table Table { get; set; }


        


    }
}