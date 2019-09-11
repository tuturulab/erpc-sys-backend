using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace erpc_system_backend.Helpers
{
    public class CompanyHelper 
    {
        [Required]
        public string Name {get; set;}
        
        [Required]
        public string Description {get; set;}

        public IFormFile Logo { get; set; }
        
        
    }
}