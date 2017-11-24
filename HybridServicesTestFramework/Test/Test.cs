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
using AppDistributionSetting = HybridServicesTestFramework.Model.AppDistributionService.AppDistributionSetting;
using static HybridServicesTestFramework.SystemConstants.SystemConstants;
namespace HybridServicesTestFramework.Test
{
    public class Test
    {
        private ConfigurationHelper _configurationHelper;
        private AdsHelper _adsHelper;
        private HybridCredentialServiceHelper _hybridCredentialService;

        [SetUp]
        public void SetUp()
        {
            _configurationHelper = new ConfigurationHelper();
            string hybridHost =
                _configurationHelper.GetHybridHost(
                    Path.GetFullPath(ProxyPath));
            _adsHelper = new AdsHelper(hybridHost);
            _hybridCredentialService = new HybridCredentialServiceHelper(hybridHost);
        }

        [TearDown]
        public async Task Teardown()
        {
            await _hybridCredentialService.DeleteCloudApiKey(HttpStatusCode.NoContent);
        }

		[Test]
		public void GetAppDistributionSettings()
		{
			var keys = _hybridCredentialService.AddCloudApiKey(HttpStatusCode.Created,
				new CloudApiKey() { Id = HawkId, Key = HawkKey }).To<CloudApiKey>().Result.Content;

			//Fluent Assertions for easier assertions
			keys.Id.Should().BeEquivalentTo(HawkId);

			var deployment = _hybridCredentialService.AddDeployment(HttpStatusCode.Created,
				new Deployment()
				{
					ServiceUrl = ServiceUrl,
					AuthenticationUrl = AuthenticationUrl,
					ClientId = ClientId,
					ClientSecret = ClientSecret,
					Type = DeploymentType.QlikCloud,
					Name = Guid.NewGuid().ToString(),
				}).To<Deployment>().Result.Content;

			deployment.Should().NotBeNull();
			deployment.AuthenticationUrl.Should().BeEquivalentTo(AuthenticationUrl);
			deployment.ServiceUrl.Should().BeEquivalentTo(ServiceUrl);

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
