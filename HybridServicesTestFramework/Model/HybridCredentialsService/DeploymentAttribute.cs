using System.ComponentModel.DataAnnotations;

namespace HybridServicesTestFramework.Model.HybridCredentialsService
{
    public class DeploymentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var deploymentModel = (DeploymentModel) validationContext.ObjectInstance;

            if (!string.IsNullOrWhiteSpace(deploymentModel.ClientId) &&
                string.IsNullOrEmpty(deploymentModel.ClientSecret))
                return new ValidationResult("Client Secret is defined, but no Client Id");

            if (string.IsNullOrWhiteSpace(deploymentModel.ClientId) &&
                !string.IsNullOrEmpty(deploymentModel.ClientSecret))
                return new ValidationResult("Client Id is defined, but no Client Secret");

            return ValidationResult.Success;
        }
    }
}