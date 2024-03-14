using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINNO_FC.Services
{
    public class HttpClientHandlerInsecure : HttpClientHandler
    {
        public HttpClientHandlerInsecure()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}
