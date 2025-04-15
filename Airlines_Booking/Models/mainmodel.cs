using System.Security.Cryptography.X509Certificates;

namespace Airlines_Booking.Models
{
    public class mainmodel
    {
        public List<admin> admin_record { get; set; }
        public List<admin> adminrecord { get; set; }
        public admin admin_data { get; set; }
        public List<user> user_record { get; set; }
        public user user_data { get; set; }
        public List<Plan> plan_record { get; set; }
        public Plan plan_data { get; set; }
        public List<Country> countries_record { get; set; }
        public Country countrydata { get; set; }
        public List<flight> flight_record { get; set; }

        public flight flight_data { get; set; }
        public List<employee> staff_record { get; set; }
        public employee staff_data { get; set; }
        public List<city> cityrecord { get; set; }
        public city city_data { get; set; }
        public Arrival_country mycountry {get;set;}
        public List<Arrival_country> mycountry_record { get; set; }
        public List<ticketBooking> booking_record { get; set; }
        public ticketBooking booking_data { get; set; }
        public List<contact> contactRecord { get; set; }
        public List<employee> emp_record { get; set; }
        public employee emp_data { get; set; }
        public List<Packages> packages_record { get; set; }
        public Packages packages_data { get; set; } 
        public List<package_booked> packages_booked { get; set; } 

    }
}
