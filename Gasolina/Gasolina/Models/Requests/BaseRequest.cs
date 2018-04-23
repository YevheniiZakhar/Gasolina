using EasySoft.Services.Common;
using EasySoft.Services.Common.Utils;
using Gasolina.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gasolina.Models.Requests
{
    [Serializable]
    public class BaseRequest
    {
        [XmlIgnore]
        public string ErrorCode { get; set; }
        [XmlIgnore]
        public Guid Guid { get; set; }
        [XmlIgnore]
        public long TransactionId { get; set; }
        [XmlIgnore]
        public int ServiceId { get; set; }
        [XmlIgnore]
        public virtual int ObjectId { get; set; }
        [XmlIgnore]
        public TransactionStatus TransactionStatus { get; set; }
        [XmlIgnore]
        public TransactionOperation Operation { get; set; }
        [XmlIgnore]
        public string StatusDetail { get; set; }
        [XmlIgnore]
        public string Account { get; set; }
        [XmlIgnore]
        public DateTime OrderDate { get; set; }
        [XmlIgnore]
        public Dictionary<string, string> ProviderItems { get; set; }
        [XmlIgnore]
        public Dictionary<string, string> ResponseItems { get; set; }

        public BaseRequest()
        {
            ProviderItems = new Dictionary<string, string>();
            ResponseItems = new Dictionary<string, string>();
        }
        public void SetStatus(TransactionStatus status, string errorCode, string statusDetail)
        {
            //TODO: Add LogGuid to log status change
            this.TransactionStatus = status;
            this.ErrorCode = Utils.FormatErrorCode(errorCode);
            this.StatusDetail = statusDetail;
            this.ResponseItems.AddOrUpdate("ProviderMessage", statusDetail);
        }
    }
}
