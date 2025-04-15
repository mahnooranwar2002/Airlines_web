using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class faq
    {
        [Key]
       public int id { get; set; }
        
        public string faq_ques { get; set; }

        public string faq_ans { get; set; }

    }
}
