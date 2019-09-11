using System.ComponentModel.DataAnnotations;

namespace erpc_system_backend.Helpers
{
    public class CompanyHelper 
    {
        [Required]
        public string Name {get; set;}
        
        [Required]
        public string Description {get; set;}

        

    }
}