using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class UpgradeMembership : IUpgradeMembership
    {
        private readonly Product product;

        public UpgradeMembership(Product product)
        {
            this.product = product;
        }
        public void Exceute()
        {
            //upgrade membership
        }
    }
    public interface IUpgradeMembership : IBussinessRule { }
}
