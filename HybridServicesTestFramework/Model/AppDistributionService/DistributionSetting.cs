using System;
using System.ComponentModel.DataAnnotations;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public class DistributionSetting : PersistentModel
    {
        [Required]
        public Guid? SourceAppId { get; set; }
        [Required]
        public string TargetStreamId { get; set; }
        public string TargetAppId { get; set; }
        [Required]
        public Guid? DeploymentId { get; set; }
    }
}
