using System;
using System.ComponentModel.DataAnnotations;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public class StreamDistributionSetting : PersistentModel
    {
        [Required]
        public Guid? SourceStreamId { get; set; }
        public string TargetStreamId { get; set; }
        public DistributionSettingStatus Status { get; set; }
        public DistributionStatus DistributionStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}