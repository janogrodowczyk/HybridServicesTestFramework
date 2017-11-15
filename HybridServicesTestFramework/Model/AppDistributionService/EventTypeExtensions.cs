using System;

namespace HybridServicesTestFramework.Model.AppDistributionService
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
                    return "appSetting.create";
                case AppDistributionEventType.DeleteSetting:
                    return "appSetting.delete";
                default:
                    throw new NotImplementedException();
            }
        }
        public static string Topic(this StreamDistributionEventType eventType)
        {
            switch (eventType)
            {
                case StreamDistributionEventType.CreateSetting:
                    return "streamSetting.create";
                case StreamDistributionEventType.DeleteSetting:
                    return "streamSetting.delete";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}