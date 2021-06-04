using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Products
{
    public class Book:Product
    {
        public Book(long id, string description, decimal amount) : base(id, description, amount)
        {
        }

        public long AgentId { get; set; }

    }
}
