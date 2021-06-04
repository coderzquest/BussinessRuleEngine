using BussinesRuleEngine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Products
{
    public class Product
    {
        public long Id { get;  }
        public string Description { get; }
        public decimal Amount { get; }
        public List<IBussinessRule> Rules { get; }
        public Product(long id, string description, decimal amount) {
            Rules = new List<IBussinessRule>();
            Id = id;
            Description = description;
            Amount = amount;
        }
    }
}
