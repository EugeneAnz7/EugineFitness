using System;
using System.Collections.Generic;

namespace EugineFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Fats.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Calories per 100g.
        /// </summary>
        public double Calories { get; set; }

        public ICollection<Meal> Meals { get; set; }

        public Food() { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            
        }

        /// <summary>
        /// Create new food.
        /// </summary>
        /// <param name="name">Name.</param>
        public Food(string name) : this(name, 0, 0, 0, 0)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
