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
   Server=127.0.0.1,1433;
   Database=Master;
   User Id=SA;
   Password=PolapPolap1
";
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }

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
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
