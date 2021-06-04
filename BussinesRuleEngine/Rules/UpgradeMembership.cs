using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Rules
{
    public class UpgradeMembership : IUpgradeMembership
    {
        
        public void Exceute(Product product)
        {
            //upgrade membership
        }
    }
    public interface IUpgradeMembership : IBussinessRule { }
}
