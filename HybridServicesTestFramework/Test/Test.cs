using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using HybridServicesTestFramework.AppDistributionService;
using HybridServicesTestFramework.GenericHelpers;
using HybridServicesTestFramework.HybridCredentialsService;
using HybridServicesTestFramework.Model.Cloud;
using NUnit.Framework;
using FluentAssertions;
using AppDistributionSetting = HybridServicesTestFramework.Model.AppDistributionService.AppDistributionSetting;
namespace HybridServicesTestFramework.Test
{
    public class Test
    {
        private ConfigurationHelper _configurationHelper;
        private AdsHelper _adsHelper;
        private NameValueCollection _appSettings;
        private HybridCredentialServiceHelper _hybridCredentialService;
        private string _hawkId = "59aea078d2e75d003cb97b5e";
        private string _hawkKey = "eDBmZkEvcXhDdm1DL2hSVkUzOFkydz09";
        private string _serviceUrl = "https://develop.qlikcloud.com/api/v1";
        private string _authenticationUrl = "https://login-dev-us-east-1.dev.qlikcloud.com";
        private string _clientId = "HVzsWgyJE7OICFQSgoH1h2hjbU7O2W6Y";
        private string _clientSecret = "VbLCgMdxak4d4KuUyfBvp385Io9Ly2KLXP6BhebhBk-eJQJuxBSwqK249oUvTVi0";

        [SetUp]
        public void SetUp()
        {
            _configurationHelper = new ConfigurationHelper();
            string hybridHost =
                _configurationHelper.GetHybridHost(
                    Path.GetFullPath("C:\\Program Files\\Qlik\\Sense\\Proxy\\Proxy.exe"));
            _adsHelper = new AdsHelper(hybridHost);
            _hybridCredentialService = new HybridCredentialServiceHelper(hybridHost);
        }

        [TearDown]
        public async Task Teardown()
        {
            await _hybridCredentialService.DeleteCloudApiKey(HttpStatusCode.NoContent);
        }

        [Test]
        public async Task GetAppDistributionSettings()
        {
            var keys = _hybridCredentialService.AddCloudApiKey(HttpStatusCode.Created,
                new CloudApiKey() {Id = _hawkId, Key = _hawkKey});
            CloudApiKey cloudApiKey = await Reader.ParseResponseMessage<CloudApiKey>(keys);
            cloudApiKey.Id.Should().BeEquivalentTo(_hawkId);
            
            var deployment = _hybridCredentialService.AddDeployment(HttpStatusCode.Created,
                new Deployment()
                {
                    ServiceUrl = _serviceUrl,
                    AuthenticationUrl = _authenticationUrl,
                    ClientId = _clientId,
                    ClientSecret = _clientSecret,
                    Type = DeploymentType.QlikCloud,
                    Name = Guid.NewGuid().ToString(),
                }).To<Deployment>().Result.Content;

            deployment.Should().NotBeNull();
            deployment.AuthenticationUrl.Should().BeEquivalentTo(_authenticationUrl);
            deployment.ServiceUrl.Should().BeEquivalentTo(_serviceUrl);
            
            var appDistributionSetting = _adsHelper.CreateAppDistributionSetting(
                new AppDistributionSetting()
                {
                    SourceAppId = Guid.NewGuid(),
                    TargetStreamId = Guid.NewGuid().ToString().Replace("-", ""),
                    DeploymentId = deployment.Id,
                }, HttpStatusCode.Created).To<AppDistributionSetting>().Result.Content;
            appDistributionSetting.TargetStreamId.Should().NotContain("-");

            var appDistributionSettings = _adsHelper.GetAppDistributionSettings(HttpStatusCode.OK)
                .To<List<AppDistributionSetting>>().Result.Content;
            appDistributionSettings.Should().Contain(i => i.Id == appDistributionSetting.Id);
            appDistributionSettings.Should().NotBeEmpty();
        }



    }
}
