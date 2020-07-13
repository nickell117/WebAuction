using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectInitial.Models;

namespace ProjectInitial.Controllers
{
    public class ListingController : Controller
    {
        private IListingRepository repository;

        public ListingController(IListingRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            Listing newListing = new Listing();
            return View(newListing);
        }

        [HttpPost]
        public IActionResult Create(Listing listing)
        {
            repository.Create(listing);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            IQueryable<Listing> allListings =
               this.repository.GetAllListings();
            return View(allListings);
        }

        public IActionResult Detail(int id)
        {
            Listing listing = repository.GetListingById(id);
            if (listing != null)
            {
                return View(listing);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string id)
        {
            IEnumerable<Listing> listings =
               repository.GetListingsByKeyword(id);
            return View(listings);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Listing listing = repository.GetListingById(id);
            if (listing != null)
            {
                return View(listing);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Listing listing, int id)
        {
            listing.Id = id;
            repository.UpdateListing(listing);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Listing product = repository.GetListingById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Listing listing)
        {
            repository.DeleteListing(listing.Id);
            return RedirectToAction("Index");
        }
    }
}
