using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace erpc_system_backend.Helpers
{
    public class ProductBought
    {
        //public int SpecsProductId { get; set; }
        //public DateTime Garantia { get; set; }
        //public string IMEI { get; set; }
        //public string Description { get; set; }

        [Required]
        public int id {get ; set; }

        [Required]
        public int Stock {get; set;}
    }
}
