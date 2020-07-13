using BusinessRuleEngine.Entities.Departments;
using BusinessRuleEngine.Entities.Payments;
using BusinessRuleEngine.Facades;
using BusinessRuleEngine.Factories;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Interfaces.Agent;
using BusinessRuleEngine.Interfaces.Commission;
using Moq;
using NUnit.Framework;

namespace BusinessRuleEngine.Tests
{
    [TestFixture]
    public class BookPaymentFacadeTests
    {
        private Mock<IPackagingSlipService> packagingSlipServiceMock;
        private Mock<ICommissionService> commissionServiceMock;
        private Mock<IAgentService> agentServiceMock;

        [SetUp]
        public void TestSetup()
        {
            packagingSlipServiceMock = new Mock<IPackagingSlipService>();
            commissionServiceMock = new Mock<ICommissionService>();
            agentServiceMock = new Mock<IAgentService>();
        }

        [Test]
        public void HandleBookPayment_Failure()
        {
            // Arrange
            var packagingSlipServiceResponse = new PackagingSlipGenerationResponse
            {
                PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Failure
            };
            packagingSlipServiceMock.Setup(c => c.GenerateDuplicateSlip(It.IsAny<Department>())).Returns(packagingSlipServiceResponse);

            var payment = CreatePayment();

            var target = new BookPaymentFacade(packagingSlipServiceMock.Object, commissionServiceMock.Object, agentServiceMock.Object);

            // Act
            var result = target.HandleBookPayment(payment);

            // Assert
            Assert.AreEqual(PaymentResponseType.Failure, result.PaymentResponseType);
            packagingSlipServiceMock.Verify(c => c.GenerateDuplicateSlip(It.IsAny<Department>()), Times.Once);
            commissionServiceMock.Verify(c => c.Calculate(It.IsAny<double>()), Times.Never);
        }

        [Test]
        public void HandleBookPayment_Success()
        {
            // Arrange
            var packagingSlipServiceResponse = new PackagingSlipGenerationResponse
            {
                PackagingSlipGenerationResponseType = PackagingSlipGenerationResponseType.Success
            };
            packagingSlipServiceMock.Setup(c => c.GenerateDuplicateSlip(It.IsAny<Department>())).Returns(packagingSlipServiceResponse);

            commissionServiceMock.Setup(c => c.Calculate(It.IsAny<double>())).Returns(10);

            var payment = CreatePayment();

            var target = new BookPaymentFacade(packagingSlipServiceMock.Object, commissionServiceMock.Object, agentServiceMock.Object);

            // Act
            var result = target.HandleBookPayment(payment);

            // Assert
            Assert.AreEqual(PaymentResponseType.Success, result.PaymentResponseType);
            packagingSlipServiceMock.Verify(c => c.GenerateDuplicateSlip(It.IsAny<Department>()), Times.Once);
            commissionServiceMock.Verify(c => c.Calculate(It.IsAny<double>()), Times.Once);
        }

        private static Payment CreatePayment()
        {
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

            return payment;
        }
    }
}