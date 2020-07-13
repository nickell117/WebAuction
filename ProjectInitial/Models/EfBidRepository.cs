using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class EfBidRepository : IBidRepository
    {

        private AppDbContext context;

        public EfBidRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Bid AddBid(Bid b)
        {
            context.Bids.Add(b);
            context.SaveChanges();
            return b;
        }

        public IQueryable<Bid> GetAllBids(int listingId)
        {
            return context.Bids.Where(b => b.ListingId == listingId)
                               .OrderBy(b => b.Price);
        }

        public Bid GetBidById(int id)
        {
            return context.Bids
                               .FirstOrDefault(b => b.Id == id);
        }
    }
}
