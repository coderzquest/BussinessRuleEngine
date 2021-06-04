using BussinesRuleEngine.Products;
using BussinesRuleEngine.Rules;
using Moq;
using System;
using Xunit;
using System.Linq;
namespace BussinesRuleEngine.Test
{
    public class VideoPackingSlipTest
    {
        
        [Fact]
        public void Execute_ForLearningToSkyVideo_AddFirstAidVideoAlso()
        {
            Product product = new Video(1234, "Learning to Ski", 1678);

            Mock<IGeneratePackingSlip> genericPackingSlip = new Mock<IGeneratePackingSlip>();


            IVideoPackingSlip rule = new VideoPackingSlip(genericPackingSlip.Object);
            rule.Exceute(product);

            genericPackingSlip.Verify(t => t.Exceute(It.IsAny<Product>()), Times.Exactly(2));
            genericPackingSlip.Verify(t => t.Exceute(It.Is<Product>(arg=>arg.Description== "Learning to Ski")),Times.Once);
            genericPackingSlip.Verify(t => t.Exceute(It.Is<Product>(arg => arg.Description == "First Aid")), Times.Once);
        }
    }
}
