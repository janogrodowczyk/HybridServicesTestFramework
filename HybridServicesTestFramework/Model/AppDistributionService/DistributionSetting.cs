using System;
using System.ComponentModel.DataAnnotations;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public class DistributionSetting : PersistentModel
    {
        public Guid? SourceAppId { get; set; }
        public string TargetStreamId { get; set; }
        public string TargetAppId { get; set; }
        public Guid? DeploymentId { get; set; }
    }
}
