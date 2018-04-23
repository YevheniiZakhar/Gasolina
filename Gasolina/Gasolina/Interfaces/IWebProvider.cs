using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Interfaces
{
    public interface IWebProvider
    {
        string ProvideRequest(Guid logGuid, WebRequest parameters);
        WebRequest CreateWebRequest(string url, string parameters);
    }
}
