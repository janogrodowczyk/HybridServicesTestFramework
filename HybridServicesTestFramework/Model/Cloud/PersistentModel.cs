using System;

namespace HybridServicesTestFramework.Model.Cloud
{
    public class PersistentModel : IPersistentModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedByUserName { get; set; }
    }
}
