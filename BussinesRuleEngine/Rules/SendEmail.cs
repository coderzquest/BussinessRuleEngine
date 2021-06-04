using System;
using System.Collections.Generic;
using System.Text;
using BussinesRuleEngine.Products;

namespace BussinesRuleEngine.Rules
{
    public class SendEmail : ISendEmail
    {
        private Product product;
        private readonly IMailSender mailSender;

        public SendEmail(Product product, IMailSender mailSender)
        {
            this.product = product;
            this.mailSender = mailSender;
        }

        public void Exceute()
        {
            mailSender?.SendMail(product);
        }
    }
    public interface ISendEmail : IBussinessRule { }
    public interface IMailSender {
        void SendMail(Product product);
    }
}
