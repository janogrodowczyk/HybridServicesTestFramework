using System.Runtime.Serialization;

namespace HybridServicesTestFramework.Model.Cloud
{
	public enum AppDistributionSettingStatus
	{
		[EnumMember(Value = "Active")] Active,
		[EnumMember(Value = "Deleting")] Deleting
	}
}