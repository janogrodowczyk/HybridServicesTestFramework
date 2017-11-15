using System.Linq;

namespace HybridServicesTestFramework.Model.Cloud
{
    public class NotificationEvent : NotificationEventPayload
    {
        public override string ToString()
        {
            return string.Join("\n", GetType().GetProperties()
                .Select(p => $"{p.Name} - {p.GetValue(this)}"));
        }
    }
}