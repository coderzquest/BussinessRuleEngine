using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class GeneratePackingSlip : IGeneratePackingSlip
    {
        private readonly ISlipGenerator generator;

        public GeneratePackingSlip(ISlipGenerator generator)
        {
            this.generator = generator;
        }
        public void Exceute(Product product)
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
