using System;
using System.Linq;
using EasyNetQ;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    [Queue("app-distribution-service:notifications", ExchangeName = "stream.notifications")]
    public class StreamDistributionEvent
    {
        public StreamDistributionEventType Event { get; set; }
        public string Topic { get; set; }
        public Guid SourceStreamId { get; set; }
        public string TargetStreamId { get; set; }

        public override string ToString()
        {
            return string.Join("\n", GetType().GetProperties()
                .Select(p => $"{p.Name} - {p.GetValue(this)}"));
        }
    }
}
