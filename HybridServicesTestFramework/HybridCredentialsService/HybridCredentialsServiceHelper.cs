using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HybridServicesTestFramework.Client;
using HybridServicesTestFramework.Model.Cloud;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HybridServicesTestFramework.HybridCredentialsService
{
    public class HybridCredentialServiceHelper
    {
        private readonly HttpClient _restClient;
        private readonly int _port = 5920;
        private readonly string _apiVersion = "v1";
        private readonly string _apiPrefix = "api/g3";
        private readonly string _serviceName = "hybrid-credentials-service";

        public HybridCredentialServiceHelper(string hostname)
        {
            _restClient = new RestClient().Client(new Uri($"https://{hostname}:{_port}/{_apiPrefix}/{_serviceName}/{_apiVersion}/"));
            _restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> AddCloudApiKey(HttpStatusCode expectedStatusCode, CloudApiKey cloudApiKey)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cloudApiKey), Encoding.UTF8, "application/json");
            var response = await _restClient.PostAsync("credentials/QlikCloud/00000000-0000-0000-0000-000000000000", content);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteCloudApiKey(HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.DeleteAsync("credentials/QlikCloud/00000000-0000-0000-0000-000000000000");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> AddDeployment(HttpStatusCode expectedStatusCode, Deployment deployment)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri("deployments"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(deployment), Encoding.UTF8, "application/json");
            requestMessage.Headers.Add("size", "original");
            var response = await _restClient.SendAsync(requestMessage);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateDeployment(HttpStatusCode expectedStatusCode, Deployment deployment)
        {
            var id = deployment.Id.ToString();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri($"deployments/{id}"));
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(deployment), Encoding.UTF8, "application/json");
            requestMessage.Headers.Add("size", "original");
            var response = await _restClient.SendAsync(requestMessage);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteDeployment(HttpStatusCode expectedStatusCode, Deployment deployment)
        {
            var id = deployment.Id.ToString();
            var response = await _restClient.DeleteAsync($"deployments/{id}");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetDeployment(HttpStatusCode expectedStatusCode, Deployment deployment)
        {
            var id = deployment.Id.ToString();
            var response = await _restClient.GetAsync($"deployments/{id}");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetDeployments(HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("deployments");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetToken(HttpStatusCode expectedStatusCode, Deployment deployment)
        {
            var id = deployment.Id.ToString();
            var response = await _restClient.GetAsync($"deployments/{id}/token");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

    }
}
