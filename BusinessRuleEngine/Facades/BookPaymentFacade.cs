using BusinessRuleEngine.Common.Logger;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Factories;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Agent;
using BusinessRuleEngine.Interfaces.Commission;
using BusinessRuleEngine.Services;

namespace BusinessRuleEngine.Facades
{
    public class BookPaymentFacade : BasePaymentFacade
    {
        private readonly IPackagingSlipService packagingSlipService;

        public BookPaymentFacade(IPackagingSlipService packagingSlipService, ICommissionService commissionService, IAgentService agentService) 
            : base(commissionService, agentService)
        {
            this.packagingSlipService = packagingSlipService;
        }

        public PaymentResponse HandleBookPayment(Payment payment)
        {
            var packagingSlipServiceResponse = packagingSlipService.GenerateDuplicateSlip(payment.Department);

            if (packagingSlipServiceResponse.PackagingSlipGenerationResponseType == PackagingSlipGenerationResponseType.Failure)
            {
                Logger.Instance.Log(LoggerType.Error, packagingSlipServiceResponse.ErrorMessage);

                return new PaymentResponse
                {
                    ErrorMessage = packagingSlipServiceResponse.ErrorMessage,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            CalculateAgentCommission(payment);

            Logger.Instance.Log(LoggerType.Information, Resources.BookPaymentSucessful);

            return new PackagingSlipPaymentResponse
            {
                PaymentResponseType = PaymentResponseType.Success,
                PackagingSlip = packagingSlipServiceResponse.PackagingSlip
            };
        }
    }
}
