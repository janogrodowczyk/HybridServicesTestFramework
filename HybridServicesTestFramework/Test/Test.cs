using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using HybridServicesTestFramework.AppDistributionService;
using HybridServicesTestFramework.GenericHelpers;
using HybridServicesTestFramework.HybridCredentialsService;
using HybridServicesTestFramework.Model.Cloud;
using NUnit.Framework;
using FluentAssertions;
namespace HybridServicesTestFramework.Test
{
    class Test
    {
        private ConfigurationHelper _configurationHelper;
        private AdsHelper _adsHelper;
        private HybridCredentialServiceHelper _hybridCredentialService;
        private string _hawkId = "59aea078d2e75d003cb97b5e";
        private string _hawkKey = "eDBmZkEvcXhDdm1DL2hSVkUzOFkydz09";

        [SetUp]
        public async Task SetUp()
        {
            _configurationHelper = new ConfigurationHelper();
            var proxyPath = Path.GetFullPath("C:\\Program Files\\Qlik\\Sense\\Proxy\\Proxy.exe");
            string hybridHost = _configurationHelper.GetRow(proxyPath, "HybridHost");
            hybridHost = hybridHost.Split(':')[0];
            _adsHelper = new AdsHelper(hybridHost);
            _hybridCredentialService = new HybridCredentialServiceHelper(hybridHost);
            try
            {
                await _hybridCredentialService.DeleteCloudApiKey(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public async Task TestHej()
        {
            try
            {
                var keys = _hybridCredentialService.AddCloudApiKey(HttpStatusCode.Created,
                    new CloudApiKey() {Id = _hawkId, Key = _hawkKey});
                CloudApiKey cloudApiKey = await Reader.ParseResponseMessage<CloudApiKey>(keys);
                cloudApiKey.Id.Should().BeEquivalentTo(_hawkId);
                var appDistributionSettings = _adsHelper.GetAppDistributionSettings(HttpStatusCode.OK);
                var adsList = await Reader.ParseResponseMessage<List<AppDistributionSetting>>(appDistributionSettings);
                adsList.Should().AllBeOfType<List<AppDistributionSetting>>();
                adsList.Should().BeEmpty();
                Console.WriteLine(adsList);
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}
