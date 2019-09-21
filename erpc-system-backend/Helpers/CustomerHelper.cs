using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Helpers
{
    public class CustomerHelper
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Document{ get; set; }

        [Required]
        public string Cellphone { get; set; }


    }
}
