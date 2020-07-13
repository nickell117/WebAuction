using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public interface IBidRepository
    {
        Bid AddBid(Bid b);

        IQueryable<Bid> GetAllBids(int listingId);

        Bid GetBidById(int id);
    }
}
