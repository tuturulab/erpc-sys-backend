using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class ProductRecibos
    {
        public String name {get; set;}
        public int quantity {get; set; }
        public Double unit_cost {get; set; } 
        
        public String description {get; set; }
    }
}
