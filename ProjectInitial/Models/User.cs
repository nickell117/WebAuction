﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectInitial.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


    }
}
