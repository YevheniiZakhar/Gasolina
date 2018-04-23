using Gasolina.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Operations
{
    class CheckOperation : Operation
    {
        public CheckOperation(Guid logGuid, IOperationProvider operationProvider)
           : base(logGuid, operationProvider)
        {
        }
    }
}
