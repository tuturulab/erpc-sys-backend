using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picture {get; set;}
        public string Description {get; set;} 

        public virtual Company Company {get; set;}
    }
}
