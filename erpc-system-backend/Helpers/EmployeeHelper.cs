using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace erpc_system_backend.Helpers
{
    public class EmployeeHelper 
    {
        [Required]
        public string Name {get; set;}
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]       
        public string Cellphone { get; set; }
        [Required]
        public string Description {get; set; }

        [Required]
        public IFormFile Picture { get; set; }
    }
}