using System;
using System.Collections.Generic;

namespace EugineFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public Activity() { }

        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Activity name can't be empty or null.", nameof(name));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
