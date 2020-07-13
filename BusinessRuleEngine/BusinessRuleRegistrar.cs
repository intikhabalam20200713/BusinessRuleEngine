using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Agent;
using BusinessRuleEngine.Interfaces.Commission;
using BusinessRuleEngine.Interfaces.Membership;
using BusinessRuleEngine.Services;
using BusinessRuleEngine.Services.Agent;
using BusinessRuleEngine.Services.Commission;
using BusinessRuleEngine.Services.Membership;
using BusinessRuleEngine.Services.Notification;
using Unity;

namespace BusinessRuleEngine
{
    public static class BusinessRuleRegistrar
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IAgentService, AgentService>();
            container.RegisterType<ICommissionService, CommissionService>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<INotificationMembershipService, NotificatiionMembershipService>();
            container.RegisterType<IEmailService, EmailService>();
            container.RegisterType<IPackagingSlipNumberGenerator, PackagingSlipNumberGenerator>();
            container.RegisterType<IPackagingSlipService, PackagingSlipService>();
        }
    }
}
