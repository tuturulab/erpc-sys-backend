using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int SubscriptionId { get; set; }
        public string Features { get; set; }

        public Plan Plan { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Deparment> Deparments { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        
    }
}
