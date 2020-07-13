using System;

namespace BusinessRuleEngine.Entities.Memberships
{
    public class Membership
    {
        public Guid Id { get; set; }

        public MembershipType MembershipType { get; set; }

        public bool IsActive { get; set; }
    }
}
