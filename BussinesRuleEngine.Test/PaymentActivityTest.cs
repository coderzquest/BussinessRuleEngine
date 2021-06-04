using BussinesRuleEngine.Products;
using BussinesRuleEngine.Rules;
using Moq;
using System;
using Xunit;

namespace BussinesRuleEngine.Test
{
    public class PaymentActivityTest
    {
        [Fact]
        public void Payment_ForPhysicalProduct_True()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            PaymentActivity master = new PaymentActivity(product);
            Assert.True(master.Pay());
        }
        [Fact]
        public void Payment_ForPhysicalProduct_GeneratePackagingSlip()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            Mock<ISlipGenerator> slipGenerator = new Mock<ISlipGenerator>();
            new GeneratePackingSlip(product, slipGenerator.Object);
            PaymentActivity master = new PaymentActivity(product);

            master.Pay();

            slipGenerator.Verify(t => t.Generate(It.IsAny<Product>()), Times.Once);
        }
        [Fact]
        public void Payment_ForBook_True()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            PaymentActivity master = new PaymentActivity(product);
            Assert.True(master.Pay());
        }
        [Fact]
        public void Payment_ForBook_GeneratePackagingSlipTwice()
        {
            Product product = new PhysicalProduct(1234, "Test Product", 100.50M);
            Mock<ISlipGenerator> slipGenerator = new Mock<ISlipGenerator>();
            IBussinessRule rule1 = new GeneratePackingSlip(product, slipGenerator.Object);
            IBussinessRule rule2 = new GeneratePackingSlip(product, slipGenerator.Object);
            PaymentActivity master = new PaymentActivity(product);

            master.Pay();

            slipGenerator.Verify(t => t.Generate(It.IsAny<Product>()), Times.Exactly(2));
        }
    }
}
