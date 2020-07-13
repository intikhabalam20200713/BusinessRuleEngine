using BusinessRuleEngine.Entities.Customers;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Membership;
using BusinessRuleEngine.Validations;

namespace BusinessRuleEngine.Services.Membership
{
    public class NotificatiionMembershipService : INotificationMembershipService
    {
        private readonly IEmailService emailService;
        private const string activateMembershipMailSubject = "Activate Membership"; // Can be kept in resource file as well.
        private const string activateMembershipMailContent = "Menbership is activated"; // Can be kept in resource file as well.
        private const string upgradeMembershipMailSubject = "Upgrade Membership"; // Can be kept in resource file as well.
        private const string upgradeMembershipMailContent = "Menbership is upgraded"; // Can be kept in resource file as well.

        public NotificatiionMembershipService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public MembershipServiceResponse ActivateNotify(Customer customer)
        {
            MembershipServiceResponse response;

            if (!customer.Validate(out response))
            {
                return response;
            }

            emailService.SendMail(customer.Email, activateMembershipMailSubject, activateMembershipMailContent);

            return new MembershipServiceResponse
            {
                MembershipServiceResponseType = MembershipServiceResponseType.Success
            };
        }

        public MembershipServiceResponse UpgradeNotify(Customer customer)
        {
            MembershipServiceResponse response;

            if (!customer.Validate(out response))
            {
                return response;
            }

            emailService.SendMail(customer.Email, activateMembershipMailSubject, activateMembershipMailContent);

            return new MembershipServiceResponse
            {
                MembershipServiceResponseType = MembershipServiceResponseType.Success
            };
        }
    }
}
