using BusinessRuleEngine.Entities.Customers;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Services.Membership;

namespace BusinessRuleEngine.Validations
{
    public static class CustomerValidation
    {
        public static bool Validate(this Customer customer, out MembershipServiceResponse response)
        {
            response = null;

            if (customer == null)
            {
                response = new MembershipServiceResponse
                {
                    ErrorMessage = Resources.CustomerCannotBeEmpty,
                    MembershipServiceResponseType = MembershipServiceResponseType.Failure
                };

                return false;
            }

            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                response = new MembershipServiceResponse
                {
                    ErrorMessage = Resources.CustomerEmailCannotBeEmpty,
                    MembershipServiceResponseType = MembershipServiceResponseType.Failure
                };

                return false;
            }

            if (customer.Membership == null)
            {
                response = new MembershipServiceResponse
                {
                    ErrorMessage = Resources.MembershipCannotBeEmpty,
                    MembershipServiceResponseType = MembershipServiceResponseType.Failure
                };

                return false;
            }

            return true;
        }
    }
}
