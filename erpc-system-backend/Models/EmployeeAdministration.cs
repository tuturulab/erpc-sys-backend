using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class EmployeeAdministration
    {
        public int EmployeeAdministrationId { get; set; }
        public int IsActive { get; set; }
        public double Salary { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
