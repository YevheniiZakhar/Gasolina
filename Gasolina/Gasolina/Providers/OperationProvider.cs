using Gasolina.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gasolina.Providers
{
    class OperationProvider : IOperationProvider
    {
        private IWebProvider webProvider { get; }

        public OperationProvider(IWebProvider _provider)
        {
            this.webProvider = _provider;
        }
    }
}
