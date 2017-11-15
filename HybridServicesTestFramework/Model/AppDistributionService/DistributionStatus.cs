using System.Runtime.Serialization;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public enum DistributionStatus
    {
        [EnumMember(Value = "Queued")] Queued,
        [EnumMember(Value = "InProgress")] InProgress,
        [EnumMember(Value = "Success")] Success,
        [EnumMember(Value = "Failure")] Failure,
        [EnumMember(Value = "Deleting")] Deleting
    }
}