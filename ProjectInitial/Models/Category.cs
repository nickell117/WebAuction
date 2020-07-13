﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Categoryname { get; set; }
    }
}
