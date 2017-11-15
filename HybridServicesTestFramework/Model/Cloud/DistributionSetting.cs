using System;

namespace HybridServicesTestFramework.Model.Cloud
{
	public class DistributionSetting : PersistentModel
	{
		public Guid? SourceAppId { get; set; }
		public string TargetStreamId { get; set; }
	}
}
