using System;
using System.Linq;

namespace HybridServicesTestFramework.Model.AppDistributionService
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

        public override string ToString()
        {
            return string.Join("\n", GetType().GetProperties().Select(p => $"{p.Name} - {p.GetValue(this)}"));
        }
    }
}