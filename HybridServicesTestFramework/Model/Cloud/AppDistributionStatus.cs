using System;

namespace HybridServicesTestFramework.Model.Cloud
{
	public class AppDistributionStatus : PersistentModel
	{
		public Guid SourceAppId { get; set; }
		public string TargetStreamId { get; set; }
		public string TargetAppId { get; set; }
		public Guid DistributionSettingId { get; set; }
		public DateTime LastSyncDate { get; set; }
		public DistributionStatus DistributionStatus { get; set; }
		public string ErrorMessage { get; set; }
	}
}
