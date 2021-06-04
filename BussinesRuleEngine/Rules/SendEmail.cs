using System;
using System.Collections.Generic;
using System.Text;
using BussinesRuleEngine.Products;

namespace BussinesRuleEngine.Rules
{
    public class SendEmail : ISendEmail
    {
       
        private readonly IMailSender mailSender;

        public SendEmail(IMailSender mailSender)
        {

            this.mailSender = mailSender;
        }

        public void Exceute(Product product)
        {
            mailSender?.SendMail(product);
        }
    }
    public interface ISendEmail : IBussinessRule { }
    public interface IMailSender {
        void SendMail(Product product);
    }
}
