using BusinessRuleEngine.Entities.Customers;

namespace BusinessRuleEngine.Interfaces
{
    public interface IMembershipService
    {
        MembershipServiceResponse Activate(Customer customer);

        MembershipServiceResponse Upgrade(Customer customer);
    }
}
