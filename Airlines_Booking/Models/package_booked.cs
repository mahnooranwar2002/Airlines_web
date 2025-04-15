using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class package_booked
    {
        [Key]
        public int booked_Id { get; set; }
        public string ticket_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string Phone_number { get; set; }
        public int Number_of_passengers { get; set; }
        public int total { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public int User_id { get; set; }
        public string paymentofmode { get; set; }
        public int cvv { get; set; }
        public string packages_name { get; set; }
        public int price_package { get; set; }
        public int package_id { get; set; }
        public int status { get; set; }
    }
}
