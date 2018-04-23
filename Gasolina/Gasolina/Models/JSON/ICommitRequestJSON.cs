using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Models.Requests
{
    class ICommitRequest 
    {
        public int value { get; set; }
        public int payment_gateway_id { get; set; }
        public int meter_value { get; set; }
        public string payment_period_start { get; set; }
        public string payment_period_end { get; set; }
        public string transaction_id { get; set; }
    }
}
