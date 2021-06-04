using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class ActivateMembership : IActivateMembership
    {
        public void Exceute(Product product)
        {
            //activate
        }
    }
    public interface IActivateMembership : IBussinessRule { }
}
