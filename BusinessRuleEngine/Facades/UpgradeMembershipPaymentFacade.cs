using BusinessRuleEngine.Common.Logger;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Factories;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Membership;

namespace BusinessRuleEngine.Facades
{
    public class UpgradeMembershipPaymentFacade
    {
        private readonly IMembershipService membershipService;
        private readonly INotificationMembershipService notificatiionMembershipService;

        public UpgradeMembershipPaymentFacade(IMembershipService membershipService, INotificationMembershipService notificatiionMembershipService)
        {
            this.membershipService = membershipService;
            this.notificatiionMembershipService = notificatiionMembershipService;
        }

        public PaymentResponse HandleUpgradeMembershipPayment(Payment payment)
        {
            var membershipServiceResponse = membershipService.Upgrade(payment.Customer);

            if (membershipServiceResponse.MembershipServiceResponseType == MembershipServiceResponseType.Failure)
            {
                Logger.Instance.Log(LoggerType.Error, membershipServiceResponse.ErrorMessage);

                return new PaymentResponse
                {
                    ErrorMessage = membershipServiceResponse.ErrorMessage,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            var notificationResponse = notificatiionMembershipService.UpgradeNotify(payment.Customer);

            if (notificationResponse.MembershipServiceResponseType == MembershipServiceResponseType.Failure)
            {
                Logger.Instance.Log(LoggerType.Error, notificationResponse.ErrorMessage);

                return new PaymentResponse
                {
                    ErrorMessage = membershipServiceResponse.ErrorMessage,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            Logger.Instance.Log(LoggerType.Information, Resources.UpgradeMembershipPaymentSucessful);

            return new PaymentResponse
            {
                PaymentResponseType = PaymentResponseType.Success
            };
        }
    }
}
