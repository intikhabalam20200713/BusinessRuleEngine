using BusinessRuleEngine.Common.Logger;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Facades;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Agent;
using BusinessRuleEngine.Interfaces.Commission;
using BusinessRuleEngine.Interfaces.Membership;
using BusinessRuleEngine.Validations;
using System;
using Unity;

namespace BusinessRuleEngine.Factories
{
    public class PaymentFactory
    {
        private readonly IUnityContainer container;

        public PaymentFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public PaymentResponse Pay(Payment payment)
        {
            PaymentResponse paymentResponse;

            if (!payment.Validate(out paymentResponse))
            {
                Logger.Instance.Log(LoggerType.Error, paymentResponse.ErrorMessage);
                return paymentResponse;
            }

            try
            {
                switch (payment.PaymentType)
                {
                    case PaymentType.PhysicalProduct:
                        PhysicalProductPaymentFacade physicalProductPaymentFacade = new PhysicalProductPaymentFacade(container.Resolve<IPackagingSlipService>(),
                            container.Resolve<ICommissionService>(),
                            container.Resolve<IAgentService>());
                        return physicalProductPaymentFacade.HandlePhysicalProductPayment(payment);

                    case PaymentType.Book:
                        BookPaymentFacade bookPaymentFacade = new BookPaymentFacade(container.Resolve<IPackagingSlipService>(),
                            container.Resolve<ICommissionService>(),
                            container.Resolve<IAgentService>());
                        return bookPaymentFacade.HandleBookPayment(payment);

                    case PaymentType.Membership:
                        MembershipPaymentFacade membershipPaymentFacade = new MembershipPaymentFacade(container.Resolve<IMembershipService>(),
                            container.Resolve<INotificationMembershipService>());
                        return membershipPaymentFacade.HandleMembershipPayment(payment);

                    case PaymentType.UpgradeMembership:
                        UpgradeMembershipPaymentFacade upgradeMembershipPaymentFacade = new UpgradeMembershipPaymentFacade(container.Resolve<IMembershipService>(),
                            container.Resolve<INotificationMembershipService>());
                        return upgradeMembershipPaymentFacade.HandleUpgradeMembershipPayment(payment);

                    case PaymentType.Video:
                        VideoPaymentFacade videoPaymentFacade = new VideoPaymentFacade(container.Resolve<IPackagingSlipService>());
                        return videoPaymentFacade.HandleVideoPayment(payment);

                    default:
                        Logger.Instance.Log(LoggerType.Error, Resources.PaymentTypeNotSupported);
                        return new PaymentResponse
                        {
                            ErrorMessage = Resources.PaymentTypeNotSupported,
                            PaymentResponseType = PaymentResponseType.Failure
                        };
                }
            }
            catch(Exception ex)
            {
                Logger.Instance.Log(LoggerType.Error, ex.Message);
                Logger.Instance.Log(LoggerType.Error, ex.StackTrace);

                return new PaymentResponse
                {
                    ErrorMessage = Resources.PaymentExceptionOccurred,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }
        }
    }
}
