using System;
using Microsoft.EntityFrameworkCore;

namespace CytecCinema.Models
{
    public class CinemaContext : DbContext
    {
        public virtual DbSet<Showing> Showings { get; set; }
        public virtual DbSet<Booking>  Bookings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=CinemaContext;User=sa; Password=reallyStrongPwd123");
        }
    }
}

