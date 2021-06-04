using BussinesRuleEngine.Products;
using System;
using Xunit;

namespace BussinesRuleEngine.Test
{
    public class PaymentActivityTest
    {
        [Fact]
        public void Payment_ForPhysicalProduct_True()
        {
            Product product = new PhysicalProduct() {
                Id = 1234,
                Description="Test Product",
                Amount=100.50M,

            };
            PaymentActivity master = new PaymentActivity(product);
            Assert.True(master.Pay());
        }
        [Fact]
        public void Payment_ForBook_True()
        {
            Product product = new Book()
            {
                Id = 1234,
                Description = "Test Product",
                Amount = 100.50M,

            };
            PaymentActivity master = new PaymentActivity(product);
            Assert.True(master.Pay());
        }
    }
}
