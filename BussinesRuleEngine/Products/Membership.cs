using BussinesRuleEngine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Products
{
    public class Membership : Product
    {
        public MembershipType Type { get; set; }
        public Membership(long id, string description, decimal amount) : base(id, description, amount)
        {
           
        }
        
    }

    public enum MembershipType {
        STANDARD,
        PREMIUM
    }
}
