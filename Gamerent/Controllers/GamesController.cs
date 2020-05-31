using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using Gamerent.Models;
using Gamerent.ViewModels;

namespace Gamerent.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var games= _context.Games.Include(m => m.Genre).ToList();

            return View(games);
        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GameFormViewModel
            {
                Genres = genres
            };

            return View("GameForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel(game)
            {
                
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);
        }







        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (game == null)
                return HttpNotFound();
            return View(game);
        }






        // GET: Movies/Random
        public ActionResult Random()
        {

            var game = new Game() { Name = "Skyrim" };
            var customers = new List<Customer>

            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomGameViewModel

            {
                Game = game,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("GameForm", viewModel);
            }







            if (game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(m => m.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.GenreId = game.GenreId;
                gameInDb.NumberInStock = game.NumberInStock;
                gameInDb.ReleaseDate = game.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }




    }

}