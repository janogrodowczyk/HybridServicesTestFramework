using System.Net.Http;


namespace HybridServicesTestFramework.Model.Test
{
    public class Response<T>
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public T Content { get; set; }
    }
}
