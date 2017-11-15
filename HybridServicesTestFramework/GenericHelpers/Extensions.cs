using System.Net.Http;
using System.Threading.Tasks;
using HybridServicesTestFramework.Model.Test;

namespace HybridServicesTestFramework.GenericHelpers
{
    public static class Extensions
    {
        public static async Task<Response<T>> To<T>(this Task<HttpResponseMessage> responsemessage)
        {
            Response<T> response = new Response<T>() { ResponseMessage = await responsemessage, Content = await Reader.ParseResponseMessage<T>(responsemessage) };
            return response;
        }
    }
}
