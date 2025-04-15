using Airlines_Booking.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Airlines_Booking.Models
{
    public class Mycontext:DbContext
    {
        public Mycontext(DbContextOptions<Mycontext> options):base (options)
        {
            
        }
        public DbSet<user> tbl_user { get; set; }
        public DbSet<admin> tbl_admin { get; set; }
        public DbSet<staff> tbl_managementStaff { get; set; }
        public DbSet<ticketBooking> tbl_airlineticket { get; set; }
        public DbSet<contact> tbl_contact { get; set; }
        public DbSet<faq> tbl_faq { get; set; }
        public DbSet<Plan> tbl_plan { get; set; }
        public DbSet<Country> tbl_country { get; set; }
        public DbSet<flight> tbl_flightsmanagement { get; set; }
        public DbSet<employee> tbl_staff { get; set; }
        public DbSet<city> tbl_city { get; set; }
        public DbSet<Packages> tbl_packages { get; set; }
        public DbSet<package_booked> tbl_packagebooking { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<flight>()
                 .HasOne(p => p.plane)
                 .WithMany(f => f.flights)
                 .HasForeignKey(p => p.Plane_id);

            modelBuilder.Entity<flight>()
                .HasOne(p => p.country)
                .WithMany(f => f.flights)
                .HasForeignKey(p => p.travel_from);

           
            modelBuilder.Entity<flight>().
                HasOne(p => p.city).
                WithMany(p => p.flightdata).
                HasForeignKey(p => p.city_id);
          

        }
    }
}
