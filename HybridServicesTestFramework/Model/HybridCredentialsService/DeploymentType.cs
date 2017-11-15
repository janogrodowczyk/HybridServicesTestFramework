using System.Runtime.Serialization;

namespace HybridServicesTestFramework.Model.HybridCredentialsService
{
    public enum DeploymentType
    {
        [EnumMember(Value = "Elastic")] Elastic,
        [EnumMember(Value = "QlikCloud")] QlikCloud
    }
}