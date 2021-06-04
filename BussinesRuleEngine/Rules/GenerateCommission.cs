using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class GenerateCommission : IGenerateCommission
    {
        private readonly Product product;

        public GenerateCommission(Product product) {
            this.product = product;
        }
        public void Exceute()
        {
            //GenerateCommision
        }
    }
    public interface IGenerateCommission : IBussinessRule { }
}
