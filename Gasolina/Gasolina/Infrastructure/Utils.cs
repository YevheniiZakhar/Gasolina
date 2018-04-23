using EasySoft.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Infrastructure
{
    public static class Utils
    {
        public static string FormatErrorCode(string errorCode)
        {
            if (String.IsNullOrWhiteSpace(errorCode))
                return "";
            if (errorCode.Equals("00", StringComparison.InvariantCultureIgnoreCase))
                return string.Empty; //if response on ICommit has null or Error code will be in InProgress

            return errorCode;
        }
        public static void AddElementsToDictionary(this ItemCollection source, Dictionary<string, string> elements)
        {
            if (elements.Count <= 0) return;
            foreach (KeyValuePair<string, string> element in elements)
            {
                source.AddorUpdate(element.Key, element.Value);
            }
        }
    }
}
