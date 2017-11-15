using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HybridServicesTestFramework.Client;
using HybridServicesTestFramework.GenericHelpers;
using HybridServicesTestFramework.Model.Cloud;
using Newtonsoft.Json;
using NUnit.Framework;
using AppDistributionStatus = HybridServicesTestFramework.Model.AppDistributionService.AppDistributionStatus;
using AppDistributionSetting = HybridServicesTestFramework.Model.AppDistributionService.AppDistributionSetting;
using DistributionStatus = HybridServicesTestFramework.Model.AppDistributionService.DistributionStatus;

namespace HybridServicesTestFramework.AppDistributionService
{
    public class AdsHelper
    {
        private readonly HttpClient _restClient;
        private readonly int _port = 5920;
        private readonly string _adsApiVersion = "v1";
        private readonly string _service = "app-distribution-service";
        private readonly string _apiPrefix = "api/g3";
        private readonly string _appDistributionSettings = "appdistributionsettings";

        public AdsHelper(string hostname)
        {
            _restClient = new RestClient().Client(new Uri($"https://{hostname}:{_port}/{_apiPrefix}/{_service}/{_adsApiVersion}/"));
            _restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetAppDistributionSettings(HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync(new Uri(_appDistributionSettings, UriKind.Relative));
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> CreateAppDistributionSetting(AppDistributionSetting appDistributionSetting, HttpStatusCode expectedStatusCode)
        {
            var content = new StringContent(JsonConvert.SerializeObject(appDistributionSetting), Encoding.UTF8, "application/json");
            var response = await _restClient.PostAsync(_appDistributionSettings, content);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> EditAppDistributionSetting(AppDistributionSetting appDistributionSetting, HttpStatusCode expectedStatusCode)
        {
            var content = new StringContent(JsonConvert.SerializeObject(appDistributionSetting), Encoding.UTF8, "application/json");
            var response = await _restClient.PutAsync(_appDistributionSettings, content);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetAppDistributionSettingById(string id, HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("/appdistributionsettings/" + id);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAppDistributionSettingById(string id, HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.DeleteAsync("/appdistributionsettings/" + id);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetAppDistributionSettingStatusById(string id, HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("/appdistributionsettings/" + id + "/status");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetAppDistributionStatus(HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("/AppDistributionStatus/");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetTopAppDistributionStatus(HttpStatusCode expectedStatusCode, int number)
        {
            var response = await _restClient.GetAsync($"/AppDistributionStatus?top={number}");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetAppDistributionStatusById(string id, HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("/AppDistributionStatus/" + id);
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetHealth(HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("/Health");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<HttpResponseMessage> GetStream(HttpStatusCode expectedStatusCode)
        {
            var response = await _restClient.GetAsync("/streams");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
            return response;
        }

        public async Task<bool> WaitForAppDistributionStatus(Guid appSourceId, string targetStreamId, DistributionStatus expectedStatus)
        {
            bool validator = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<AppDistributionStatus> adsList = new List<AppDistributionStatus>();
            while (sw.Elapsed < TimeSpan.FromSeconds(30))
            {
                var adsResponse = GetTopAppDistributionStatus(HttpStatusCode.OK, 20000);
                StreamReader reader = new StreamReader(await adsResponse.Result.Content.ReadAsStreamAsync());
                var response = reader.ReadToEnd();
                adsList = Serialize.ParseResponse<List<AppDistributionStatus>>(response);
                if (adsList.Any(i => i.SourceAppId == appSourceId && i.TargetStreamId == targetStreamId))
                {
                    var appDistributionStatus = adsList.FirstOrDefault(i => i.SourceAppId == appSourceId && i.TargetStreamId == targetStreamId);
                    if (appDistributionStatus != null && appDistributionStatus.DistributionStatus == expectedStatus)
                    {
                        validator = true;
                        break;
                    }
                }
            }
            if (validator == false)
            {
                foreach (var ads in adsList)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(ads));
                }
            }
            sw.Stop();
            return validator;
        }

        public async Task<bool> WaitForAppDistributionSettingToBeDeleted(string id, HttpStatusCode statusCode)
        {
            bool validator = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.Elapsed < TimeSpan.FromSeconds(10))
            {
                try
                {
                    var res = await GetAppDistributionSettingById(id, HttpStatusCode.NotFound);
                    if (res.StatusCode == statusCode)
                    {
                        validator = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    //Ignore
                }
            }
            sw.Stop();
            return validator;
        }

        public async Task<HttpResponseMessage> CreateAndValidateAppDistributionSetting(dynamic app, CloudStreamEntity stream, Deployment deployment, HttpStatusCode expectedStatusCode = HttpStatusCode.Created)
        {
            AppDistributionSetting appDistributionSetting = new AppDistributionSetting() { SourceAppId = app.ID, TargetStreamId = stream.Id, DeploymentId = deployment.Id, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, ModifiedByUserName = "axg" };
            var res = await CreateAppDistributionSetting(appDistributionSetting, expectedStatusCode);
            if (expectedStatusCode == HttpStatusCode.Created)
            {
                StreamReader reader = new StreamReader(await res.Content.ReadAsStreamAsync());
                var response = reader.ReadToEnd();
                appDistributionSetting = Serialize.ParseResponse<AppDistributionSetting>(response);
                Assert.AreEqual(appDistributionSetting.SourceAppId, app.ID, "The returned sourceAppId was incorrect. Reponse body: " + response);
                Assert.AreEqual(appDistributionSetting.TargetStreamId, stream.Id, "The returned TargetStreamId was incorrect. Reponse body: " + response);
            }
            return res;
        }
    }
}
