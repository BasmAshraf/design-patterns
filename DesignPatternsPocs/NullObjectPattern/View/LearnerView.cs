using System;
using NullObjectPattern.Entities;

namespace NullObjectPattern.View
{
    public class LearnerView
    {
        private readonly ILearner _learner;

        public LearnerView(ILearner learner)
        {
            _learner = learner;
        }

        public void RenderView()
        {
            Console.WriteLine("User Name: " + _learner.UserName);
            Console.WriteLine("Courses Completed: " + _learner.CoursesCompleted);
        }
    }
}