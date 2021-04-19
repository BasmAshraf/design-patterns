using NullObjectPattern.Entities;
using NullObjectPattern.Services;
using NullObjectPattern.View;
using System;

namespace NullObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LearnerService learnerService = new LearnerService();
            ILearner learner = learnerService.GetCurrentLearner();

            LearnerView view = new LearnerView(learner);
            view.RenderView();
        }
    }
}
