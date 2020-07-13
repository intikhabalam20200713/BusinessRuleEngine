using BusinessRuleEngine.Entities.Memberships;
using System;

namespace BusinessRuleEngine.Entities.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Membership Membership { get; set; }
    }
}
