using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext // classe  generique pour  configurer la  base 
    {
        public DbSet<plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }


        // etablir  la  connection ou  la chaine  de connection 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AirportManagement;   
            Integrated Security=true;MultipleActiveResultSets=true");  // Mesure  de  securite  
        }

        // Methode  qui  va  faire  appel aux  classe de configurations  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration ());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());


            //Has  un  Type  Complex 
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName, full =>
            {
                full.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
            });
                //configuration de tph
                //.HasDiscriminator<int>("PassengerType")
                // .HasValue<Passenger>(0)
                //.HasValue<Traveller>(1)
                //.HasValue<Staff>(2);

            //configuration de tpt

            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");


        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }

    }
}
