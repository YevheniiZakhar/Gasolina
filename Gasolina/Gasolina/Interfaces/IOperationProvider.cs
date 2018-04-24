using Gasolina.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Interfaces
{
    public interface IOperationProvider
    {
        string CheckSettlements(Transaction transaction, Guid logGuid);
        string Payment(Transaction transaction, Guid logGuid);
        string Commit(Transaction transaction, Guid logGuid);
        string Cancel(Transaction transaction, Guid logGuid);

    }
}
