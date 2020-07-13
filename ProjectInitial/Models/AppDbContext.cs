using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Listing>   Listings   { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating
        (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Listing>().HasData
               (new Listing
               {
                   Id = 1,
                   Title = "Kayak",
                   Description = "A 1-Person Boat",
                   Currentbid = 275M
               });

            modelBuilder.Entity<Listing>().HasData
               (new Listing
               {
                   Id = 2,
                   Title = "Life Jacket",
                   Description = "Protective AND Fashionable",
                   Currentbid = 48.95M
               });

            modelBuilder.Entity<Listing>().HasData
               (new Listing
               {
                   Id = 3,
                   Title = "Soccer Ball",
                   Description = "FIFA Approved Size And Weight",
                   Currentbid = 34.95M
               });

            modelBuilder.Entity<Listing>().HasData
               (new Listing
               {
                   Id = 4,
                   Title = "Corner Flags",
                   Description = "Like The Pros",
                   Currentbid = 19.50M
               });
        }
    }
}
