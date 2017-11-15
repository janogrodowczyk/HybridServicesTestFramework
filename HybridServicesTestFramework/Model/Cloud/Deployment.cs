using System.Runtime.Serialization;

namespace HybridServicesTestFramework.Model.Cloud
{
	public class Deployment : PersistentModel
	{
		public string Name { get; set; }
		public DeploymentType Type { get; set; }
		public string ServiceUrl { get; set; }
		public string AuthenticationUrl { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
	}

	public enum DeploymentType
	{
		[EnumMember(Value = "Elastic")] Elastic,
		[EnumMember(Value = "QlikCloud")] QlikCloud
	}
}
