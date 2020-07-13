using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class Bid
    {       
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Timestamp { get; set; }

        [ForeignKey("Listing")]
        public int ListingId { get; set; }
        public Listing Listing { get; set; }

        [ForeignKey("User")]

        public int Userid { get; set; }
        public User User { get; set; }

    }
}
