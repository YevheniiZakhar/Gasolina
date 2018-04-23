using EasySoft.Services.Common;
using EasySoft.Services.Loggers;
using EasySoft.Services.Management;
using System;
using System.Threading;
using System.Configuration.Assemblies;
using EasySoft.Services.Common.Utils;
using Gasolina.Infrastructure;
using EasySoft.Services.Common.Exceptions;
using Gasolina.Providers;

namespace Gasolina
{
    public class Service : IManagement, ITransaction
    {
        public ServiceResponse ServiceResponse { get; private set; }

        public OperationFactory OperationFactory = new OperationFactory();

        public ServiceResponse DoRequest(ServiceRequest request)
        {
            Guid logGuid = Guid.NewGuid();

            try
            {
                Logger.FileAddMessage(logGuid, "[==================== SERVICEREQUEST ==================]\r\n");
                Logger.FileAddMessage(logGuid, Utilities.ClassToString(request));
                Locker.Lock(request.TransactionId, logGuid);
                ServiceResponse = OperationFactory
                    .CreateOperation(logGuid, request.Operation, new OperationProvider(new WebProvider()))
                    .ProcessRequest(request);


            }
            catch (Exception ex)
            {
                Logger.FileAddMessage(logGuid, "[==================== ERROR PROCESSING ==================]\r\n");
                string message = ex.GetAllExceptionMessage(withStack: true);
                Logger.FileAddMessage(logGuid, message);
                Logger.Error(logGuid, request.System, request.TransactionId, request.ServiceId,
                    System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                Locker.Unlock(request.TransactionId, logGuid);
                if (ServiceResponse != null)
                    Logger.FileAddMessage(logGuid, $"[==================== SERVICERESPONSE ==================]\r\n" +
                                                   $"{Utilities.ClassToString(ServiceResponse)}");
                Logger.FileFlushMessage(logGuid);
            }
            return ServiceResponse;
        }

        public void Start()
        {
            try
            {
                Logger.FileWrite("[====== START SERVICE ======]");
                //Do thmth
                Logger.FileWrite("[====== START SERVICE OK ======]");
            }
            catch (Exception ex)
            {
                Logger.FileWrite("[====== START SERVICE ERROR ======]");
                Logger.FileWrite($"Exception:\r\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        public void Stop()
        {
            try
            {
                Logger.FileWrite("[====== STOP SERVICE ======]");
                //Do thmth
                Logger.FileWrite("[====== STOP SERVICE OK ======]");
            }
            catch (Exception ex)
            {
                Logger.FileWrite("[====== STOP SERVICE ERROR ======]");
                Logger.FileWrite($"Exception:\r\n{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
