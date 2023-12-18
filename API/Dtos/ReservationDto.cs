namespace Core.Entities
{
    public class ReservationDto
    {
       

        public int Id { get; set; }
       
        public string GuestName { get; set; }
        public string TableName { get; set; }

        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
       
    }
}
