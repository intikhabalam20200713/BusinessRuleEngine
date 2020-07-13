using BusinessRuleEngine;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Factories;
using System;
using Unity;

namespace BusinessRuleVerificationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            BusinessRuleRegistrar.Register(container);

            var paymentFactory = new PaymentFactory(container);
            var payment = new Payment
            {
                Agent = new BusinessRuleEngine.Entities.Agents.Agent
                {
                    Name = "Intikhab"
                },
                Customer = new BusinessRuleEngine.Entities.Customers.Customer
                {
                    Name = "Joe",
                    Email = "joe@email.com",
                    Membership = new BusinessRuleEngine.Entities.Memberships.Membership
                    {
                        IsActive = false,
                        MembershipType = BusinessRuleEngine.Entities.Memberships.MembershipType.Normal
                    }
                },
                Department = new BusinessRuleEngine.Entities.Departments.Department
                {
                    DepartmentType = BusinessRuleEngine.Entities.Departments.DepartmentType.Royality,
                    Name = "Royality Dept."
                },
                PaymentType = PaymentType.Book,
                PaymentValue = 10,
                VideoType = BusinessRuleEngine.Entities.Videos.VideoType.LearningToSki
            };

            var response = paymentFactory.Pay(payment);

            if (response.PaymentResponseType == PaymentResponseType.Success)
            {
                Console.WriteLine($"Payment is successful for the payment type = '{payment.PaymentType.ToString()}'.");
            }
            else
            {
                Console.WriteLine("Payment Failed. Reasoin is given below.");
                Console.WriteLine(response.ErrorMessage);
            }

            Console.ReadLine();
        }
    }
}
