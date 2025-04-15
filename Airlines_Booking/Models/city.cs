using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class city
    {
        [Key]
        public int id { get; set; }
        public string city_name { get; set; }

        public List<flight> flightdata { get; set; }
        public List <ticketBooking> ticket_Book { get; set; }
    }
}
