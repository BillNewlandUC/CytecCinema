using System;
namespace CytecCinema.Models
{
    public class Booking
    {
        public Booking()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public virtual Showing Showing { get; set;}
        public Guid ShowingId { get; set; }
        public string CustomerName { get; set; }
        public int TicketsBought { get; set; }
    }
}
