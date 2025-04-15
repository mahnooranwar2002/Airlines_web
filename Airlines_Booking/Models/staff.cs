using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string status_update { get; set; }

    }
}
