using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Products
{
    public class Video : Product
    {
        public Video(long id, string description, decimal amount) : base(id, description, amount)
        {
        }
    }
}
