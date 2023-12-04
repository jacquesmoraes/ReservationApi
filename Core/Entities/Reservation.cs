namespace Core.Entities
{
    public class Reservation : BaseEntity
    {

        public string GuestName { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfPeople { get; set; }

        public int TableId { get; set; }
        public virtual Table Table { get; set; }

        


    }
}