using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<flight> flights { get; set; }
    }
}
