using System.ComponentModel.DataAnnotations;

namespace HybridServicesTestFramework.Model.HybridCredentialsService
{
    [Deployment]
    public class DeploymentModel : PersistentModel
    {
        public string Name { get; set; }

        public DeploymentType Type { get; set; }

        [Url]
        public string ServiceUrl { get; set; }

        [Url]
        public string AuthenticationUrl { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}