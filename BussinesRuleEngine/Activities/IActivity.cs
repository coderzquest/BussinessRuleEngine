using BussinesRuleEngine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine.Activities
{
    public interface IActivity
    {
        List<IBussinessRule> Rules { get; }
        bool Execute();
    }
}
