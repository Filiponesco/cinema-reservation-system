using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_reservation_system_individual_auth.entities;
using Microsoft.EntityFrameworkCore;

namespace cinema_reservation_system_individual_auth
{
    public class CinemaDbContext : DbContext
    {
        private string _connectionString =
            @"
   Data Source=tcp:cinema-reservation-server.database.windows.net,1433;
Initial Catalog=CinemaReservationDatabase;
User ID=student-ms;
Password=PolapPolap1;
";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<Room>()
               .Property(u => u.Name)
               .IsRequired().HasMaxLength(64);

            modelBuilder.Entity<Room>()
               .Property(u => u.SeatsCount)
               .IsRequired();

            modelBuilder.Entity<Movie>()
               .Property(u => u.Name)
               .IsRequired().HasMaxLength(500);

            modelBuilder.Entity<Movie>()
              .Property(u => u.DurationInMinutes)
              .IsRequired();
            modelBuilder.Entity<Seance>()
             .Property(u => u.DateTime)
             .IsRequired();
            modelBuilder.Entity<Seance>()
             .Property(u => u.RoomId)
             .IsRequired();
            modelBuilder.Entity<Seance>()
             .Property(u => u.MovieId)
             .IsRequired();

            modelBuilder.Entity<Reservation>()
            .Property(u => u.SeanceId)
            .IsRequired();
            modelBuilder.Entity<Reservation>()
            .Property(u => u.UserId)
            .IsRequired();
            modelBuilder.Entity<Reservation>()
            .Property(u => u.Count)
            .IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
