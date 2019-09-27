using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Vacation
    {
        public int VacationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Observation { get; set; }

        public Employee Employee { get; set; }
    }
}
