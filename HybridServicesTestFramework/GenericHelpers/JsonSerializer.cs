using System;
using Newtonsoft.Json;

namespace HybridServicesTestFramework.GenericHelpers
{
    public static class Serialize
    {
        public static T ParseResponse<T>(string body)
        {
            T res = default(T);

            try
            {
                res = JsonConvert.DeserializeObject<T>(body);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return res;
        }

    }
}
