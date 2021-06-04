using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class GeneratePackingSlip : IGeneratePackingSlip
    {
        private readonly Product product;
        private readonly ISlipGenerator generator;

        public GeneratePackingSlip(Product product, ISlipGenerator generator)
        {
            this.product = product;
            this.generator = generator;
        }
        public void Exceute()
        {
            generator?.Generate(product);
        }
    }
    public interface IGeneratePackingSlip : IBussinessRule { }
    public interface ISlipGenerator
    {
        void Generate(Product product);
    }
}
