using System;

namespace EugineFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Fats.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Calories per 100g.
        /// </summary>
        public double Calories { get; }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: Check

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
