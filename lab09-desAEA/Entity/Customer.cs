﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    {
        public int Customer_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public string Phone { get; set; }
        public bool Active { get; set; }

    }
}
