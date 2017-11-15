using System.Runtime.Serialization;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public enum DistributionSettingStatus
    {
        [EnumMember(Value = "Active")] Active,
        [EnumMember(Value = "Deleting")] Deleting,
        [EnumMember(Value = "Duplicate")] Duplicate
    }
}