using Entity_Agents = BusinessRuleEngine.Entities.Agents;

namespace BusinessRuleEngine.Interfaces.Agent
{
    public interface IAgentService
    {
        void ReceieveCommission(Entity_Agents.Agent agent, double commission);
    }
}
