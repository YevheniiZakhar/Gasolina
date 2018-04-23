using EasySoft.Services.Common;
using Gasolina.Models.Requests;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using Gasolina.Interfaces;
using EasySoft.Services.Loggers;
using Gasolina.Infrastructure;

namespace Gasolina.Operations
{
    public class Operation
    {
        protected Stopwatch timer = new Stopwatch();
        /// <summary>
        /// Object to Save payment to DB
        /// </summary>
        protected ProviderPayment payment = null;
        /// <summary>
        /// SessionId from ServiceRequest
        /// </summary>
        protected Guid sessionId;
        /// <summary>
        /// Using to save Request
        /// </summary>
        protected XmlDocument providerReq = new XmlDocument();
        /// <summary>
        /// Using to save Response
        /// </summary>
        protected XmlDocument providerResp = new XmlDocument();
        /// <summary>
        /// Track request date to Provider
        /// </summary>
        protected DateTime reqTime;
        /// <summary>
        /// Track response date to Provider
        /// </summary>
        protected DateTime respTime;
        protected List<decimal> AllowedAmmount { get; }
        protected Guid LogGuid { get; private set; }

        protected BaseRequest BaseRequest = new BaseRequest();
        protected IOperationProvider OperationProvider { get; }

        public Operation(Guid logGuid, IOperationProvider operationProvider)
        {
            LogGuid = logGuid;
            OperationProvider = operationProvider;
           // this.AllowedAmmount = new List<decimal>(ConfigurationManager.AppSettings.Get("AllowedAmmount")
           // .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
           //     .Select(amount => Decimal.Parse(amount, NumberStyles.Integer, new CultureInfo("ru-Ru"))));
        }

        public virtual ServiceResponse ProcessRequest(ServiceRequest req)
        {
            //init base Items
            ServiceResponse response = new ServiceResponse
            {
                GUID = BaseRequest.Guid,
                TransactionStatus = BaseRequest.TransactionStatus,
                StatusDetail = BaseRequest.StatusDetail,
                DatePost = BaseRequest.OrderDate,
                TransactionId = BaseRequest.TransactionId,
                ErrorCode = BaseRequest.ErrorCode
            };
            response.Items.AddElementsToDictionary(BaseRequest.ResponseItems);

            if (!String.IsNullOrWhiteSpace(BaseRequest.ErrorCode))
                response.ErrorCode = BaseRequest.ErrorCode;
            Logger.FileAddMessage(LogGuid, "[==================== RESPONSE MODEL MAPPEDD IN OPERATION.cs ==================]\r\n",
                Utilities.ClassToString(response));
            return response;
        }
    }
}
