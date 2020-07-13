using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class Listing
    {
        
        [Key]
        public int      Id          { get; set; }
        public string   Title       { get; set; }
        public string   Description { get; set; }
        public decimal  Startbid    { get; set; }
        public decimal  Currentbid  { get; set; }
        public string   Starttime   { get; set; }
        public string   Endtime     { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("User")]
        public int Userid { get; set; }
        public User User { get; set; }
        
    }
}
