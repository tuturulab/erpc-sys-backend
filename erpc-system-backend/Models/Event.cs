using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public String title {get; set;}
        public DateTime end { get; set; }
        public DateTime start { get; set; }

        public Account Company { get; set; }
    }
}
