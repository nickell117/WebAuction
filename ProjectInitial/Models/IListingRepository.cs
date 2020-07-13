using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public interface IListingRepository
    {
        Listing Create(Listing listing);


        public IQueryable<Listing> GetAllListings();
        public Listing GetListingById(int listingId);
        public IQueryable<Listing> GetListingsByKeyword(string keyword);

        Listing UpdateListing(Listing listing);

        bool DeleteListing(int id);

    }
}
