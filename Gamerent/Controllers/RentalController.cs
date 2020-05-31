using Gamerent.Models;
using Gamerent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamerent.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
      
        
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(RentalDto RentalDto)
        {
            var game = _context.Games.Single(
                c => c.Id == RentalDto.GameId);
            var customer = _context.Customers.Single(
                c => c.Id == RentalDto.CustomerId);

            var rental = new Rental
            {
                game = game,
                customer = customer,
                DateRental = DateTime.Now
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();



            return RedirectToAction("Index", "Customers");
        }
    }
}