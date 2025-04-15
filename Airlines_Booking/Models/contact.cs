using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class contact
    {
        [Key]
      public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public string subject { get; set; }

        public string msg { get; set; }
    }
}
