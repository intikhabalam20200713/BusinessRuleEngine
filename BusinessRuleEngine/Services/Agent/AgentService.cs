using BusinessRuleEngine.Interfaces.Agent;
using System;
using Entity_Agents = BusinessRuleEngine.Entities.Agents;

namespace BusinessRuleEngine.Services.Agent
{
    public class AgentService : IAgentService
    {
        public void ReceieveCommission(Entity_Agents.Agent agent, double commission)
        {
            Console.WriteLine($"Agent with name '{agent.Name}' recceived a commission of value = '{commission}'.");
        }
    }
}
