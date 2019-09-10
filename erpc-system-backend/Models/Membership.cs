using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Membership
    {
        public int MembershipId { get; set; }

        /// <summary>
        /// Type acces, { ReadOnly, ReadWrite, Admin or Owner } we might not need this(more validations).
        /// Do not use till we realize if its necessary or not.
        /// </summary>
        public string Access { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
