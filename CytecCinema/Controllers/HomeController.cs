using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CytecCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace CytecCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new BookingViewModel();
            using (var c = new CinemaContext())
            {
                vm.Showings = c.Showings.ToList().Select(s => new ShowingViewModel { Id = s.Id, Performance = $"{s.MovieName} at {s.ShowingAt}" });
                vm.Booking = new Booking();

            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BookingViewModel view)
        {

            var booking = view.Booking;
            Booking result = null;
            using (var c = new CinemaContext())
            {
                var sold = c.Bookings.Where(c => c.ShowingId == booking.ShowingId).Sum(b => b.TicketsBought);
                var capacity = c.Showings.FirstOrDefault(s => s.Id == booking.ShowingId).Capacity;
                var available = capacity - sold;
                if (available < booking.TicketsBought)
                {
                    var showing = c.Showings.FirstOrDefault(s => s.Id == booking.ShowingId);
                    return View("SoldOut", new BookingFailViewModel { Performance = $"{showing.MovieName} at {showing.ShowingAt}", TicketsAvailable = available, TicketsBought = booking.TicketsBought });
                }
                else
                {
                    c.Bookings.Add(booking);
                    c.SaveChanges();
                    result = c.Bookings.Include(a => a.Showing).FirstOrDefault(b => b.Id == booking.Id);
                    return View("Confirmation", new ConfirmationViewModel { Booking = result });
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
