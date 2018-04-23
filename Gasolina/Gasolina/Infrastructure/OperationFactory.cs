using EasySoft.Services.Common;
using EasySoft.Services.Loggers;
using Gasolina.Interfaces;
using Gasolina.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Infrastructure
{
    public class OperationFactory
    {
        private IOperationProvider OperationProvider { get; set; }
        public Operation CreateOperation(Guid logGuid, TransactionOperation transactionOperation, IOperationProvider operationProvider)
        {
            Operation operation = null;
            if (operationProvider != null)
            {
                OperationProvider = operationProvider;
            }
            else
            {
                throw new ArgumentException("Provider cann't be null");
            }
            switch (transactionOperation)
            {
                case TransactionOperation.CheckPayment:
                    operation = new CheckOperation(logGuid, OperationProvider);
                    break;
                case TransactionOperation.IPayment:
                    operation = new IPaymentOperation(logGuid, OperationProvider);
                    break;
                case TransactionOperation.ICommit:
                    operation = new ICommitOperation(logGuid, OperationProvider);
                    break;
                case TransactionOperation.Cancel:
                    operation = new CancelOperation(logGuid, OperationProvider);
                    break;
                default:
                    string msg = $"TransactionOperation {OperationProvider} not supported";
                    Logger.WriteLoggerError(msg);
                    throw new ArgumentOutOfRangeException(msg);
            }
            return operation;
        }
    }
}
