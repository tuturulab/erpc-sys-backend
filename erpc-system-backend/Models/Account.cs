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
        public ICollection<Membership> Memberships { get; set; }
    }
}
