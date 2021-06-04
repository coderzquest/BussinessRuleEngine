using BussinesRuleEngine.Activities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesRuleEngine
{
    public class WorkflowManger: IWorkflowManger
    {
        private readonly List<IActivity> activities;

        public WorkflowManger(List<IActivity> activities) {
            this.activities = activities;
        }

        public void ExecuteActivities()
        {
            if (activities != null)
                foreach (var activity in activities)
                    activity.Execute();
        }
    }

    public interface IWorkflowManger {
        void ExecuteActivities();
    }
}
