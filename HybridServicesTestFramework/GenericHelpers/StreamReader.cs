using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Sprache;

namespace HybridServicesTestFramework.GenericHelpers
{
    public static class Reader
    {
        private static async Task<string> ReadContent(Task<HttpResponseMessage> responseMessage)
        {
            StreamReader reader = new StreamReader(await responseMessage.Result.Content.ReadAsStreamAsync());
            return await reader.ReadToEndAsync();
        }

        public static async Task<T> ParseResponseMessage<T>(Task<HttpResponseMessage> responseMessage)
        {
            var json = await ReadContent(responseMessage);
            return Serialize.ParseResponse<T>(json.ToString());
        }

    }
}
