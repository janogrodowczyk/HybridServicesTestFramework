using Newtonsoft.Json;

namespace HybridServicesTestFramework.Model.HybridCredentialsService
{
    public class OauthTokenRequest
    {
        [JsonProperty(PropertyName = "audience")]
        public string Audience { get; set; }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }
    }
}