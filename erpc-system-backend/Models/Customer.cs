﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Cellphone { get; set; }

        public Account Account { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}