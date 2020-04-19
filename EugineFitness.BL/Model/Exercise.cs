using System;

namespace EugineFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get;}
        public DateTime End { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime start, DateTime end, Activity activity, User user)
        {
            // TODO: Check

            Start = start;
            End = end;
            Activity = activity;
            User = user;
        }
    }
}
