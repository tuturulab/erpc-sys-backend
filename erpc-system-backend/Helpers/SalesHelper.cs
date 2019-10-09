using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Helpers
{
    public class SalesHelper 
    {
        public int Id { get; set; }
        //public DateTime Date { get; set; }
        //public string Code { get; set; }
        public string Type { get; set; }

        [Required]        
        public int CustomerId { get; set; }

        public virtual ICollection<ProductBought> ProductsBought {get; set; }

    }
}