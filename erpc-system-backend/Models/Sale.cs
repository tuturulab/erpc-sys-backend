using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erpc_system_backend.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }

        public Customer Customer { get; set; }
        public Account Account { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
