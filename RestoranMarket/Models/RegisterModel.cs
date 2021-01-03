﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [UIHint("email")]
        public string Email { get; set; }

    }
}
