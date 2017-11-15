using System;

namespace HybridServicesTestFramework.Model.AppDistributionService
{
    public interface IPersistentModel
    {
        Guid Id { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string ModifiedByUserName { get; set; }
    }
}
