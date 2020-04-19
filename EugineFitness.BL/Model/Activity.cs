﻿using System;

namespace EugineFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {
            // TODO: Check
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
