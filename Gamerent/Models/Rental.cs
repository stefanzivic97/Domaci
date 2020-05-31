using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamerent.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Customer customer { get; set; }

        public Game game { get; set; }

        public DateTime DateRental { get; set; }
    }
}