using BussinesRuleEngine.Products;
using BussinesRuleEngine.Rules;
using Moq;
using System;
using Xunit;
using System.Linq;
namespace BussinesRuleEngine.Test
{
    public class PaymentActivityTest
    {
        [Fact]
        public void Payment_ForAnyProduct_True()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            PaymentActivity master = new PaymentActivity(product);
            Assert.True(master.Pay());
        }
        [Fact]
        public void Payment_ForPhysicalProduct_GeneratePackagingSlip()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);

            Mock<IGeneratePackingSlip> slipGeneratorRule = new Mock<IGeneratePackingSlip>();
            Mock<IGenerateCommission> generateCommissionRule = new Mock<IGenerateCommission>();

            product.Rules.Add(slipGeneratorRule.Object);
            product.Rules.Add(generateCommissionRule.Object);

            PaymentActivity master = new PaymentActivity(product);
            master.Pay();

            slipGeneratorRule.Verify(t => t.Exceute(), Times.Once);
            generateCommissionRule.Verify(t => t.Exceute(), Times.Once);
        }
        [Fact]
        public void Payment_ForBook_GeneratePackagingSlipTwice()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            Mock<IGeneratePackingSlip> slipGeneratorRule = new Mock<IGeneratePackingSlip>();
            Mock<IGenerateCommission> generateCommissionRule = new Mock<IGenerateCommission>();

            product.Rules.Add(slipGeneratorRule.Object);
            product.Rules.Add(slipGeneratorRule.Object);
            product.Rules.Add(generateCommissionRule.Object);

            PaymentActivity master = new PaymentActivity(product);

            master.Pay();

            slipGeneratorRule.Verify(t => t.Exceute(), Times.Exactly(2));
            generateCommissionRule.Verify(t => t.Exceute(), Times.Once);
        }
        [Fact]
        public void Payment_ForActivateMemberShip_ActivateAndSendEmail()
        {
            Product product = new Membership(1234, "RentalMovie", 999);

            Mock<ISendEmail> sendMailRule = new Mock<ISendEmail>();
            Mock<IActivateMembership> activateMemberShipRule = new Mock<IActivateMembership>();

            product.Rules.Add(sendMailRule.Object);
            product.Rules.Add(activateMemberShipRule.Object);

            PaymentActivity master = new PaymentActivity(product);
            master.Pay();

            sendMailRule.Verify(t => t.Exceute(), Times.Once);
            activateMemberShipRule.Verify(t => t.Exceute(), Times.Once);
        }
        [Fact]
        public void Payment_ForUpgradeMemberShip_UpgradeAndSendEmail()
        {
            Product product = new Membership(1234, "RentalMovie", 999);

            Mock<ISendEmail> sendMailRule = new Mock<ISendEmail>();
            Mock<IUpgradeMembership> upgradeMembershipRule = new Mock<IUpgradeMembership>();

            product.Rules.Add(sendMailRule.Object);
            product.Rules.Add(upgradeMembershipRule.Object);

            PaymentActivity master = new PaymentActivity(product);
            master.Pay();

            sendMailRule.Verify(t => t.Exceute(), Times.Once);
            upgradeMembershipRule.Verify(t => t.Exceute(), Times.Once);
        }
    }
}
