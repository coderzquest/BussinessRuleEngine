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
            PaymentActivity activity = new PaymentActivity(product);
            Assert.True(activity.Execute());
        }
        [Fact]
        public void Payment_ForPhysicalProduct_GeneratePackagingSlip()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);

            Mock<IGeneratePackingSlip> slipGeneratorRule = new Mock<IGeneratePackingSlip>();
            Mock<IGenerateCommission> generateCommissionRule = new Mock<IGenerateCommission>();

            PaymentActivity activity = new PaymentActivity(product);
            activity.Rules.Add(slipGeneratorRule.Object);
            activity.Rules.Add(generateCommissionRule.Object);
            activity.Execute();

            slipGeneratorRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
            generateCommissionRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
        }
        [Fact]
        public void Payment_ForBook_GeneratePackagingSlipTwice()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            Mock<IGeneratePackingSlip> slipGeneratorRule = new Mock<IGeneratePackingSlip>();
            Mock<IGenerateCommission> generateCommissionRule = new Mock<IGenerateCommission>();

            
            PaymentActivity activity = new PaymentActivity(product);
            activity.Rules.Add(slipGeneratorRule.Object);
            activity.Rules.Add(slipGeneratorRule.Object);
            activity.Rules.Add(generateCommissionRule.Object);

            activity.Execute();

            slipGeneratorRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Exactly(2));
            generateCommissionRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
        }
        [Fact]
        public void Payment_ForActivateMemberShip_ActivateAndSendEmail()
        {
            Product product = new Membership(1234, "RentalMovie", 999);

            Mock<ISendEmail> sendMailRule = new Mock<ISendEmail>();
            Mock<IActivateMembership> activateMemberShipRule = new Mock<IActivateMembership>();

            PaymentActivity activity = new PaymentActivity(product);
            activity.Rules.Add(sendMailRule.Object);
            activity.Rules.Add(activateMemberShipRule.Object);
            activity.Execute();

            sendMailRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
            activateMemberShipRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
        }
        [Fact]
        public void Payment_ForUpgradeMemberShip_UpgradeAndSendEmail()
        {
            Product product = new Membership(1234, "RentalMovie", 999);

            Mock<ISendEmail> sendMailRule = new Mock<ISendEmail>();
            Mock<IUpgradeMembership> upgradeMembershipRule = new Mock<IUpgradeMembership>();

           
            PaymentActivity activity = new PaymentActivity(product);
            activity.Rules.Add(sendMailRule.Object);
            activity.Rules.Add(upgradeMembershipRule.Object);
            activity.Execute();

            sendMailRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
            upgradeMembershipRule.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
        }
        [Fact]
        public void Payment_ForAnyVideo_GenerateVideoSlip()
        {
            Product product = new Video(1234, "Terminator", 1678);

            Mock<IVideoPackingSlip> videoPackingSlip = new Mock<IVideoPackingSlip>();

            PaymentActivity activity = new PaymentActivity(product);
            activity.Rules.Add(videoPackingSlip.Object);
            activity.Execute();

            videoPackingSlip.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Once);
        }
    }
}
