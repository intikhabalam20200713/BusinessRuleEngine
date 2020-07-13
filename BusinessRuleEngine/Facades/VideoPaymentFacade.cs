using BusinessRuleEngine.Common.Logger;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Factories;
using BusinessRuleEngine.Interfaces;

namespace BusinessRuleEngine.Facades
{
    public class VideoPaymentFacade
    {
        private readonly IPackagingSlipService packagingSlipService;

        public VideoPaymentFacade(IPackagingSlipService packagingSlipService)
        {
            this.packagingSlipService = packagingSlipService;
        }

        public PaymentResponse HandleVideoPayment(Payment payment)
        {
            if (payment.VideoType != Entities.Videos.VideoType.LearningToSki)
            {
                Logger.Instance.Log(LoggerType.Error, Resources.VideoTypeNotLearning);

                return new PaymentResponse
                {
                    ErrorMessage = Resources.VideoTypeNotLearning,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            var packagingSlipServiceResponse = packagingSlipService.GenerateSlipWithVideo();

            if (packagingSlipServiceResponse.PackagingSlipGenerationResponseType == PackagingSlipGenerationResponseType.Failure)
            {
                Logger.Instance.Log(LoggerType.Error, packagingSlipServiceResponse.ErrorMessage);

                return new PaymentResponse
                {
                    ErrorMessage = packagingSlipServiceResponse.ErrorMessage,
                    PaymentResponseType = PaymentResponseType.Failure
                };
            }

            Logger.Instance.Log(LoggerType.Information, Resources.VideoPaymentSucessful);

            return new PaymentResponse
            {
                PaymentResponseType = PaymentResponseType.Success
            };
        }
    }
}
