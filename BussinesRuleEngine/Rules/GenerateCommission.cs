using BussinesRuleEngine.Products;
using BussinesRuleEngine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class GenerateCommission : IGenerateCommission
    {
        public void Exceute(Product product)
        {
            //GenerateCommision
        }
    }

    public interface IGenerateCommission : IBussinessRule { }
}
