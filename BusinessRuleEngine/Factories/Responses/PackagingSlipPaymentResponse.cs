using BusinessRuleEngine.Entities.Slips;

namespace BusinessRuleEngine.Factories
{
    public class PackagingSlipPaymentResponse : PaymentResponse
    {
        public PackagingSlip PackagingSlip { get; set; }
    }
}
