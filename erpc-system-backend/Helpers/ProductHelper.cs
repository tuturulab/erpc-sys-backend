using System.ComponentModel.DataAnnotations;

namespace erpc_system_backend.Helpers
{
    public class ProductHelper 
    {
        [Required]
        public string Name {get; set;}
        
        [Required]
        public string Description {get; set;}

        [Required]
        public double Price {get; set;}

        public int Stock {get; set;}

    }
}