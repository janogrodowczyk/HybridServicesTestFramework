using System;

namespace HybridServicesTestFramework.Model.Cloud
{
	public class NotificationEventPayload
	{
		public NotificationEventType Event { get; set; }
		public string Topic { get; set; }
		public string ResourceType { get; set; }
		public string ResourceId { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ModifiedByUserName { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
