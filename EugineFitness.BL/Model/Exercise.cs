using System;

namespace EugineFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime end, Activity activity, User user)
        {
            Start = start;
            End = end;
            Activity = activity;
            User = user;
        }
    }
}
