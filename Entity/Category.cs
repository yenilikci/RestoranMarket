﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
