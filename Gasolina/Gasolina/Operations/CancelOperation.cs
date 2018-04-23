using Gasolina.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Operations
{
    class CancelOperation : Operation
    {
        public CancelOperation(Guid logGuid, IOperationProvider operationProvider)
           : base(logGuid, operationProvider)
        {
        }
    }
}
