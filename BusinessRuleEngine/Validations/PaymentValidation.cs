using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Factories;

namespace BusinessRuleEngine.Validations
{
    public static class PaymentValidation
    {
        public static bool Validate(this Payment payment, out PaymentResponse paymentResponse)
        {
            paymentResponse = null;

            if (payment == null)
            {
                paymentResponse = new PaymentResponse
                {
                    ErrorMessage = Resources.PaymentCannotBeEmpty,
                    PaymentResponseType = PaymentResponseType.Failure
                };

                return false;
            }

            if (payment.Customer == null)
            {
                paymentResponse = new PaymentResponse
                {
                    ErrorMessage = Resources.CustomerCannotBeEmpty,
                    PaymentResponseType = PaymentResponseType.Failure
                };

                return false;
            }

            if (payment.Agent == null)
            {
                paymentResponse = new PaymentResponse
                {
                    ErrorMessage = Resources.AgentCannotBeEmpty,
                    PaymentResponseType = PaymentResponseType.Failure
                };

                return false;
            }

            if (payment.Department == null)
            {
                paymentResponse = new PaymentResponse
                {
                    ErrorMessage = Resources.DepartmentCannotBeEmpty,
                    PaymentResponseType = PaymentResponseType.Failure
                };

                return false;
            }

            if (payment.PaymentValue == 0)
            {
                paymentResponse = new PaymentResponse
                {
                    ErrorMessage = Resources.PaymentValueCannotBeZeo,
                    PaymentResponseType = PaymentResponseType.Failure
                };

                return false;
            }

            return true;
        }
    }
}
