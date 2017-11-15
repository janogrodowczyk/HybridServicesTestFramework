using System;

namespace HybridServicesTestFramework.Model.Cloud
{
	public static class EventTypeExtensions
	{
		public static string Topic(this NotificationEventType eventType)
		{
			switch (eventType)
			{
				case NotificationEventType.PublishApp:
					return "app.publish";
				case NotificationEventType.ReloadApp:
					return "app.reload";
				case NotificationEventType.DeleteApp:
					return "app.delete";
				case NotificationEventType.DeleteStream:
					return "stream.delete";
				default:
					throw new NotImplementedException();
			}
		}

		public static string Topic(this AppDistributionEventType eventType)
		{
			switch (eventType)
			{
				case AppDistributionEventType.CreateSetting:
					return "setting.create";
				case AppDistributionEventType.DeleteSetting:
					return "setting.delete";
				default:
					throw new NotImplementedException();
			}
		}
	}
}