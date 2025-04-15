using Airlines_Booking.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airlines_Booking.Models
{
    public class ticketBooking
    {
        [Key]
        public int myid { get; set; }
        public string ticket_id { get; set; }
     public string flight_name { get; set; }
        public string gate { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string Phone_number { get; set; }
        public string date { get; set; }
        public int Status { get; set; }
        public int barrage { get; set; }
        public string booking_status { get; set; }
        public int Number_of_passengers { get; set; }
         public string paid { get; set; }
        public int broadpass { get; set; }
        public int price { get; set; }
        public int total { get; set; }
        public string category { get; set; }
        public int User_id { get; set; }
        public string  paymentofmode {get;set;}
        public int cvv { get; set; }
      public  int city_id { get; set; }
        public string timing { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public int Country_id { get; set; }
        public int plane_id { get; set; }
        public int baggage { get; set; }
        public string seat_num { get; set; }
      
    }
}
