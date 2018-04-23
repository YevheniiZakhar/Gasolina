using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Models.Responses
{
    class ICommitResponseJSON
    {
        public int id { get; set; }
        public int value { get; set; }
        public int transaction_id { get; set; }
        public int account_no { get; set; }
    }
}
