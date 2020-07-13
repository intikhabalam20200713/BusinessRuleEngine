using BusinessRuleEngine.Entities.Departments;
using BusinessRuleEngine.Factories;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Services;

namespace BusinessRuleEngine.Validations
{
    public static class DepartmentValidation
    {
        public static bool Validate(this Department department, out PackagingSlipGenerationResponse response)
        {
            response = null;

            if (department == null)
            {
                response = new PackagingSlipGenerationResponse
                {
                    ErrorMessage = Resources.DepartmentNotProvided,
                    PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Failure
                };

                return false;
            }

            if (department.DepartmentType != DepartmentType.Royality)
            {
                response = new PackagingSlipGenerationResponse
                {
                    ErrorMessage = Resources.DepartmentNotRoyality,
                    PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Failure
                };

                return false;
            }

            return true;
        }
    }
}
