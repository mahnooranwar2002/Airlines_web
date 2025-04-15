using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class Plan
    {
        [Key]
        public int id { get; set; }
        public string plan_id { get; set; }
        public string plan_name { get; set; }
      

        public List<flight> flights { get; set; }
    }
}
