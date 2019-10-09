using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Interview
    {
        public int InterviewId { get; set; }
        public DateTime ToInterview { get; set; }
        public string Curriculum { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string DocumentNumber { get; set; }

        public bool Result { get; set; }

        public Account Account { get; set; }

    }
}
