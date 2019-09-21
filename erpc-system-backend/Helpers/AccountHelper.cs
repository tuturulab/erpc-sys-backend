using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Helpers
{
    public class AccountHelper
    {
       [Required]
        public string Features { get; set; }
    }
}
