using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace HybridServicesTestFramework.Client
{
    public class RestClient
    {
        public HttpClient Client(Uri baseUri)
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.SslProtocols = SslProtocols.Tls12;
            handler.ClientCertificates.Add(new X509Certificate2(@"C:\Users\axg\.hybrid_manager\exported_certs\client.pfx", "supersecret"));
            return new HttpClient(handler) {BaseAddress = baseUri};
        }
    }
}
