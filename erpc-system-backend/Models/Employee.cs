using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public string Cellphone { get; set; }

        public ICollection<Vacation> Vacations { get; set; }
        public Account Account { get; set; }
        public EmployeeAdministration EmployeeAdministration { get; set; }
    }
}
