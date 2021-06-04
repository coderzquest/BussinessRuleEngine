using BussinesRuleEngine.Products;
using BussinesRuleEngine.Rules;
using Moq;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace BussinesRuleEngine.Test
{
    public class WorkflowMangerTest
    {
        
        [Fact]
        public void ExecuteActivities_Should_Execute_Activites()
        {
            Mock<IPaymentActivity> paymentActivity = new Mock<IPaymentActivity>();

            IWorkflowManger manger = new WorkflowManger(new List<Activities.IActivity> { paymentActivity.Object });
            manger.ExecuteActivities();

            paymentActivity.Verify(t => t.Execute(), Times.Once);
        }
    }
}
