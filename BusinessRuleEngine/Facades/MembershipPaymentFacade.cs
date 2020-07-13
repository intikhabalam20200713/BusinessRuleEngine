using BusinessRuleEngine.Common.Logger;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Factories;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Membership;

namespace BusinessRuleEngine.Facades
{
    public class MembershipPaymentFacade
    {
        private readonly IMembershipService membershipService;
        private readonly INotificationMembershipService notificatiionMembershipService;

        public MembershipPaymentFacade(IMembershipService membershipService, INotificationMembershipService notificatiionMembershipService) 
        {
            this.membershipService = membershipService;
            this.notificatiionMembershipService = notificatiionMembershipService;
        }

        public PaymentResponse HandleMembershipPayment(Payment payment)
        {
            var membershipServiceResponse = membershipService.Activate(payment.Customer);

            if (membershipServiceResponse.MembershipServiceResponseType == MembershipServiceResponseType.Failure)
            {
                Logger.Instance.Log(LoggerType.Error, membershipServiceResponse.ErrorMessage);

                return new PaymentResponse
                {
                    ErrorMessage = membershipServiceResponse.ErrorMessage,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            var notificationResponse = notificatiionMembershipService.ActivateNotify(payment.Customer);

            if (notificationResponse.MembershipServiceResponseType == MembershipServiceResponseType.Failure)
            {
                Logger.Instance.Log(LoggerType.Error, membershipServiceResponse.ErrorMessage);

                return new PaymentResponse
                {
                    ErrorMessage = membershipServiceResponse.ErrorMessage,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            Logger.Instance.Log(LoggerType.Information, Resources.MembershipPaymentSucessful);

            return new PaymentResponse
            {
                PaymentResponseType = PaymentResponseType.Success
            };
        }
    }
}
