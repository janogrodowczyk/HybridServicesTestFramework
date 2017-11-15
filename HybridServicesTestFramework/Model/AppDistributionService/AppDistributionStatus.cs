﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public class AppDistributionStatus : PersistentModel
    {
        [Required]
        public Guid SourceAppId { get; set; }
        [Required]
        public string TargetStreamId { get; set; }
        public string TargetAppId { get; set; }
        public Guid DistributionSettingId { get; set; }
        public DateTime LastSyncDate { get; set; }
        public DistributionStatus DistributionStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
