using System;
using Gamerent.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gamerent.Controllers.Api
{
    public class GameController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContext Context => _context;

        public GameController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetGames(string query = null)
        {
            var gameQuery = _context.Games;


            return Ok(gameQuery);
        }
        public IHttpActionResult GetGames(int id)
        {
            var game = Context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return NotFound();

            return Ok(game);
        }

    }
}
