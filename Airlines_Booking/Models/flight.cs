using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class flight
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int travel_from { get; set; }
        public string airline_date { get; set; }
        public string duration { get; set; }
         public int city_id { get; set; }

        public string travel_to { get; set; }
       
        public int Status { get; set; } 
        public int Price { get; set; }
        public int Seats { get; set; }
        public int Plane_id { get; set; }
        public string Timing { get; set; }
        public string cities { get; set; }
        public int busneiss_seats { get; set; }
        public int economy_seats { get; set; }
        public int seat_avaiable  { get; set; }
        public string arrived_time { get; set; }   
        public city city { get; set; }
        public Country country { get; set; }
        public Plan plane { get; set; }
    
      
    }
}
