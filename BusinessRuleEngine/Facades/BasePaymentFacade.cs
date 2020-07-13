using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Interfaces.Agent;
using BusinessRuleEngine.Interfaces.Commission;
using Unity;

namespace BusinessRuleEngine.Facades
{
    public class BasePaymentFacade
    {
        protected readonly ICommissionService commissionService;
        protected readonly IAgentService agentService;

        public BasePaymentFacade(ICommissionService commissionService, IAgentService agentService)
        {
            this.commissionService = commissionService;
            this.agentService = agentService;
        }

        public void CalculateAgentCommission(Payment payment)
        {
            var commission = commissionService.Calculate(payment.PaymentValue);

            agentService.ReceieveCommission(payment.Agent, commission);
        }
    }
}
