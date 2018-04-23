using Gasolina.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Operations
{
    class ICommitOperation : Operation
    {
        public ICommitOperation(Guid logGuid, IOperationProvider operationProvider)
           : base(logGuid, operationProvider)
        {
        }
    }
}
