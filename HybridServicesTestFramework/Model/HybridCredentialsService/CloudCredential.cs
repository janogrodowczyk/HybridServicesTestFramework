namespace HybridServicesTestFramework.Model.HybridCredentialsService
{
    public class CloudCredential : PersistentModel
    {
        public string ServiceName { get; set; }
        public string TenantId { get; set; }
        public string Credentials { get; set; }
    }
}