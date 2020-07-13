using BusinessRuleEngine.Entities.Agents;
using BusinessRuleEngine.Entities.Customers;
using BusinessRuleEngine.Entities.Departments;
using BusinessRuleEngine.Entities.Videos;
using System;

namespace BusinessRuleEngine.Entities.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Customer Customer { get; set; }

        public PaymentType PaymentType { get; set; }

        public Department Department { get; set; }

        public Agent Agent { get; set; }

        public double PaymentValue { get; set; }

        public VideoType VideoType { get; set; }
    }
}
