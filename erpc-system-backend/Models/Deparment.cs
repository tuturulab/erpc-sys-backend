using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Deparment
    {
        public int DeparmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Account Account { get; set; }

    }
}
