using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class FakeListingRepository //: IListingRepository
    {
        public IQueryable<Listing> GetAllListings()
        {
            Listing[] result = new Listing[3];

            result[0] = new Listing { Title = "Football", Currentbid = 25 };
            result[1] = new Listing { Title = "Surf Board", Currentbid = 179 };
            result[2] = new Listing { Title = "Running Shoes", Currentbid = 95 };

            return result.AsQueryable<Listing>();
        }

        public Listing GetListingById(int listingId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Listing> GetListingsByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Listing UpdateListing(Listing listing)
        {
            throw new NotImplementedException();
        }
    }
}
