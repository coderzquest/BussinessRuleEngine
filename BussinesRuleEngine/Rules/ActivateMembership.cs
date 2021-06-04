using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class ActivateMembership : IActivateMembership
    {
        private readonly Product product;

        public ActivateMembership(Product product) {
            this.product = product;
        }
        public void Exceute()
        {
            //activate
        }
    }
    public interface IActivateMembership : IBussinessRule { }
}
