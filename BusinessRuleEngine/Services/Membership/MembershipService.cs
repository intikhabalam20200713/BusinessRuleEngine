using BusinessRuleEngine.Entities.Customers;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Validations;

namespace BusinessRuleEngine.Services.Membership
{
    public class MembershipService : IMembershipService
    {
        public MembershipServiceResponse Activate(Customer customer)
        {
            MembershipServiceResponse response;

            if (!customer.Validate(out response))
            {
                return response;
            }

            customer.Membership.IsActive = true;

            return new MembershipServiceResponse
            {
                MembershipServiceResponseType = MembershipServiceResponseType.Success
            };
        }

        public MembershipServiceResponse Upgrade(Customer customer)
        {
            MembershipServiceResponse response;

            if (!customer.Validate(out response))
            {
                return response;
            }

            customer.Membership.MembershipType = Entities.Memberships.MembershipType.Premium;

            return new MembershipServiceResponse
            {
                MembershipServiceResponseType = MembershipServiceResponseType.Success
            };
        }
    }
}
