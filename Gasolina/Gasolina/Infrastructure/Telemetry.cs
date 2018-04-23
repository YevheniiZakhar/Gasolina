using EasySoft.Services.Common.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Infrastructure
{
    public static class Telemetry
    {
        public static EasySoft.Services.Common.Public.CreateFastPaymentModelRequest RequestClient { get; set; }
        public static EasySoft.Services.Common.Public.CreateFastPaymentModelResponse ResponseClient { get; set; }
        public static EasySoft.Services.Common.Public.RemoteException remoteException { get; set; }
        static Telemetry()
        {
            if (RequestClient == null)
            {
                RequestClient = new CreateFastPaymentModelRequest();
            }

            if (ResponseClient == null)
            {
                ResponseClient = new CreateFastPaymentModelResponse();
            }

            if(remoteException == null)
            {
                remoteException = new RemoteException();
            }
        }
    }
}
