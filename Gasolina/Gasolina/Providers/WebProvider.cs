using EasySoft.Services.Common.Exceptions;
using EasySoft.Services.Loggers;
using Gasolina.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Providers
{
    class WebProvider : IWebProvider
    {
        /// <summary>
        /// Init WebRequest with parameters
        /// </summary>
        /// <param name="url">Provider url endpoint</param>
        /// <param name="parameters">parameters to send</param>
        /// <returns></returns>
        public WebRequest CreateWebRequest(string url, string parameters)
        {
            //string url = ConfigurationManager.AppSettings.Get("ProviderUrl");

            if (string.IsNullOrWhiteSpace(parameters) || string.IsNullOrEmpty(parameters))
                throw new ArgumentException("Must specify parameters fo WEBrequest");

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrEmpty(url))
                throw new ArgumentException("ProviderUrl is not Set in web.config or TM");

            WebRequest req = WebRequest.CreateHttp(url);
          //  req.Timeout = Convert.ToInt32(TimeSpan.Parse(ConfigurationManager.AppSettings.Get("RequestTimeout")).TotalMilliseconds);
            req.Method = "POST";
            req.ContentType = "text/xml";
          //  if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("UseSertificate")))
          //      ((HttpWebRequest)req).ClientCertificates.Add(SertificateProvider.LycaCertificate);
            byte[] reqData = Encoding.UTF8.GetBytes(parameters);
            req.ContentLength = reqData.Length;
            //req.ClientCertificates.Add(SertificateProvider.LycaCertificate); //using HHTPS throw VPN
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(reqData, 0, reqData.Length);
            }
            return req;
        }

        /// <summary>
        /// Get response from WebRequest
        /// </summary>
        /// <param name="logGuid"></param>
        /// <param name="webRequest">WebRequest to send</param>
        /// <returns>response from provider</returns>
        public string ProvideRequest(Guid logGuid, WebRequest webRequest)
        {
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    string msg = $"PROVIDER_RESPONSE_ERROR. StatusCode={webResponse.StatusCode}";
                    Logger.FileAddMessage(logGuid, msg);

                    throw new CustomException(msg);
                }
                else
                {
                    using (Stream responseStream = webResponse.GetResponseStream())
                    {
                        if (responseStream == null)
                            throw new ArgumentNullException(nameof(responseStream), "responseStream is null");

                        using (StreamReader sr = new StreamReader(responseStream))
                        {
                            return sr.ReadToEnd();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw new CustomException("PROVIDER_CONNECTION_ERROR", ex.GetAllExceptionMessage(withStack: true)); ;
            }
        }
    }
}
