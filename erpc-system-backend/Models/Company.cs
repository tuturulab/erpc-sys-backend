using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Logo {get; set;}
        public string Description {get; set;} 

        public virtual ICollection<Product> Products {get; set;}
    }
}
