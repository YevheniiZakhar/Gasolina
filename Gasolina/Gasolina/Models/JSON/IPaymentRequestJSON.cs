using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Models.Requests
{
    class IPaymentRequest 
    {
        public int value { get; set; }
        public string value_date { get; set; }
    }
}
