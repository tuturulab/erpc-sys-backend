using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class SpecsProduct
    {
        public int SpecsProductId { get; set; }
        public DateTime Garantia { get; set; }
        public string IMEI { get; set; }
        public string Description { get; set; }

        

        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
