using BusinessRuleEngine.Entities.Slips;

namespace BusinessRuleEngine.Interfaces
{
    public class PackagingSlipGenerationResponse
    {
        public string ErrorMessage { get; set; }

        public PackagingSlip PackagingSlip { get; set; }

        public PackagingSlipGenerationResponseType PackagingSlipGenerationResponseType { get; set; }
    }
}
