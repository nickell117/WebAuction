using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectInitial.Models;

namespace ProjectInitial.Controllers
{
    public class BidController : Controller
    {
        private IBidRepository repository;

        public BidController(IBidRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Add(int id) 
        {
            Bid b = new Bid();
            b.Userid = id;
            return View(b);
        }

        [HttpPost]
        public IActionResult Add(Bid b)
        {
            repository.AddBid(b);
            return RedirectToAction("Detail", "Listing", new { id = b.ListingId });
        }
    }
}
