using BusinessRuleEngine.Interfaces;
using System;

namespace BusinessRuleEngine.Services
{
    public class PackagingSlipNumberGenerator : IPackagingSlipNumberGenerator
    {
        public string Generate()
        {
            return "PS-" + DateTime.Now.Ticks.ToString();
        }
    }
}
