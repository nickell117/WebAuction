using System.Linq;

namespace ProjectInitial.Models
{
    public class EfListingRepository : IListingRepository
    {
        private AppDbContext context;

        public EfListingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Listing Create(Listing listing)
        {
            context.Listings.Add(listing);
            context.SaveChanges();
            return listing;
        }


        public IQueryable<Listing> GetAllListings()
        {
            return context.Listings;
        }
        public Listing GetListingById(int listingId)
        {
            return context.Listings
               .Where(l => l.Id == listingId)
               .FirstOrDefault();
        }

        public IQueryable<Listing> GetListingsByKeyword(string keyword)
        {
            return context.Listings
               .Where(l => l.Title.Contains(keyword));
        }

        public Listing UpdateListing(Listing listing)
        {
            Listing listingToUpdate =
               context.Listings
               .SingleOrDefault(l => l.Id == listing.Id);
            if (listingToUpdate != null)
            {
                listingToUpdate.Description = listing.Description;
                listingToUpdate.Title = listing.Title;
                listingToUpdate.Startbid = listing.Startbid;
                listingToUpdate.Currentbid = listing.Currentbid; 
                listingToUpdate.Endtime = listing.Endtime;
                context.SaveChanges();
            }
            return listingToUpdate;
        }

        public bool DeleteListing(int id)
        {
            Listing listingToDelete = context.Listings.FirstOrDefault(l => l.Id == id);
            if (listingToDelete == null)
            {
                return false;
            }
            context.Listings.Remove(listingToDelete);
            context.SaveChanges();
            return true;
        }

    }
}
