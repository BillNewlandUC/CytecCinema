using System;
using System.Collections.Generic;

namespace CytecCinema.Models
{
    public class BookingViewModel
    {
     

        public IEnumerable<ShowingViewModel> Showings { get;  set; }

        public Booking Booking { get; set; }

    }
}
