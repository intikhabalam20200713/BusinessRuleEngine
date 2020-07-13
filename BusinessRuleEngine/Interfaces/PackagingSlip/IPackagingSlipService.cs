using BusinessRuleEngine.Entities.Departments;
using BusinessRuleEngine.Services;

namespace BusinessRuleEngine.Interfaces
{
    public interface IPackagingSlipService
    {
        PackagingSlipGenerationResponse GenerateNewSlip();

        PackagingSlipGenerationResponse GenerateDuplicateSlip(Department department);

        PackagingSlipGenerationResponse GenerateSlipWithVideo();
    }
}
