using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class GeneratePackingSlip : IBussinessRule
    {
        private readonly Product product;
        private readonly ISlipGenerator generator;

        public GeneratePackingSlip(Product product, ISlipGenerator generator)
        {
            this.product = product;
            this.generator = generator;
            product.Rules.Add(this);
        }
        public void Exceute()
        {
            generator.Generate(product);
        }
    }

    public interface ISlipGenerator
    {
        void Generate(Product product);
    }
}
