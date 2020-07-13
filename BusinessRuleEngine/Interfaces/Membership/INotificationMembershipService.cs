using BusinessRuleEngine.Entities.Customers;

namespace BusinessRuleEngine.Interfaces.Membership
{
    public interface INotificationMembershipService 
    {
        MembershipServiceResponse ActivateNotify(Customer customer);

        MembershipServiceResponse UpgradeNotify(Customer customer);
    }
}
