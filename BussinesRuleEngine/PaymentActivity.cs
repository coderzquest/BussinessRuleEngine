﻿using BussinesRuleEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine
{
    public class PaymentActivity : IPaymentActivity
    {
        Product _product = null;
        public PaymentActivity(Product product) {
            _product = product;
        }
        public bool Pay()
        {
            var isPaymentSuccesFull=ProcessPayment();
            if(!isPaymentSuccesFull)
                return false;

            return true;
        }
        private bool ProcessPayment() {
            return true;
        }
    }
}
