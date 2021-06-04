using BussinesRuleEngine.Activities;
using BussinesRuleEngine.Products;
using BussinesRuleEngine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine
{
    public class PaymentActivity : IPaymentActivity
    {
        Product _product = null;
        public List<IBussinessRule> Rules { get; }
        public PaymentActivity(Product product)
        {
            _product = product;
            Rules = new List<IBussinessRule>();
        }
        public bool Execute()
        {
            var isPaymentSuccesFull = ProcessPayment();
            if (!isPaymentSuccesFull)
                return false;
            foreach (var rule in Rules)
                rule.Exceute(_product);
            return true;
        }
        private bool ProcessPayment()
        {
            return true;
        }
    }
    public interface IPaymentActivity : IActivity { }
}
