using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class VideoPackingSlip : IVideoPackingSlip
    {
        private readonly IGeneratePackingSlip generatePackinSlip;

        public VideoPackingSlip(IGeneratePackingSlip generatePackinSlip) {
            this.generatePackinSlip = generatePackinSlip;
        }
        public void Exceute(Product product)
        {
            generatePackinSlip.Exceute(product);
            if (product.Description == "Learning to Ski") {
                var firstAidProduct = new Video(333, "First Aid", 344);
                this.Exceute(firstAidProduct);
            }
        }
    }

    public interface IVideoPackingSlip : IBussinessRule { }
}
