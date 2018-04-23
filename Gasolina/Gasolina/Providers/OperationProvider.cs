using Gasolina.Interfaces;
using Gasolina.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EasySoft.Services.Loggers;
using System.Net;

namespace Gasolina.Providers
{
    class OperationProvider : IOperationProvider
    {
        private IWebProvider webProvider { get; }

        public OperationProvider(IWebProvider _provider)
        {
            this.webProvider = _provider;
        }

        public string Check(Transaction transaction, Guid logGuid)
        {
            CheckPaymentJSON requestCheckPaymentJSON = new CheckPaymentJSON();
            // init requestCheckPaymentJSON 
            string requestData = JsonConvert.SerializeObject(requestCheckPaymentJSON);

            Logger.FileAddMessage(logGuid, $"REQUEST CHECK: {requestData}");
            WebRequest request = webProvider.CreateWebRequest("URL", requestData);
            string response = webProvider.ProvideRequest(logGuid, request);
            Logger.FileAddMessage(logGuid, $"RESPONSE CHECK: {response}");
            return response;
        }

        public string Payment(Transaction transaction, Guid logGuid)
        {
            throw new NotImplementedException();
        }

        public string Commit(Transaction transaction, Guid logGuid)
        {
            throw new NotImplementedException();
        }

        public string Cancel(Transaction transaction, Guid logGuid)
        {
            throw new NotImplementedException();
        }
    }
}
