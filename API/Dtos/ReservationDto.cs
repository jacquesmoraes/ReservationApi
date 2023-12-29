using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class ReservationDto
    {
       

        public int Id { get; set; }
       
        public string GuestName { get; set; }
        public string TableName { get; set; }

        public int NumberOfPeople { get; set; }

       [JsonIgnore]
        public DateTime ReservationDate { get; set; }
        public string ReservationDtoDate => ReservationDate.ToString("yyyy-MM-dd");

        public TimeSpan ReservationTime { get; set; }
       
    }
}
