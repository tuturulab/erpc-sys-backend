using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace erpc_system_backend.Helpers
{
    public class ProductHelper 
    {

        public int Id { get; set; }

        [Required]
        public string Name {get; set;}
        
        [Required]
        public string Description {get; set;}

        [Required]
        public bool Ecommerce {get; set;}

        [Required]
        public double Price {get; set;}

        [Required]
        public int Stock {get; set;}

        public IFormFile Picture { get; set; }

    }
}