using Gasolina.Interfaces;
using Gasolina.Models.Requests;
using System;
using Newtonsoft.Json;
using EasySoft.Services.Loggers;
using System.Net;
using System.Configuration;

namespace Gasolina.Providers
{
    class OperationProvider : IOperationProvider
    {
        private string GSUrl = ConfigurationManager.AppSettings.Get("url");
        private IWebProvider webProvider { get; }
        public OperationProvider(IWebProvider _provider)
        {
            this.webProvider = _provider;
        }

        public string CheckSettlements(Transaction transaction, Guid logGuid)
        {
            CheckPaymentJSON requestCheckPaymentJSON = new CheckPaymentJSON();
            // init requestCheckPaymentJSON 
            string requestData = JsonConvert.SerializeObject(requestCheckPaymentJSON);

            Logger.FileAddMessage(logGuid, $"REQUEST CheckSettlements: {requestData}");
            int id = 1;                                                                       // HARDCODE
            string fullUrl = GSUrl + $"/api/v2/cities/{id}/cities";
            WebRequest request = webProvider.CreateWebRequest(fullUrl, requestData);
            string response = webProvider.ProvideRequest(logGuid, request);
            Logger.FileAddMessage(logGuid, $"RESPONSE CheckSettlements: {response}");
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
