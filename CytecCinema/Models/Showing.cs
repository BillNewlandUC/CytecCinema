using System;
namespace CytecCinema.Models
{
    public class Showing
    {
        public Showing()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime ShowingAt { get; set; }

        public string MovieName { get; set; }

        public int Capacity { get; set; }
    }
}
