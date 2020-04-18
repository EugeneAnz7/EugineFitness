using System;
using System.Collections.Generic;
using System.Linq;

namespace EugineFitness.BL.Model
{
    /// <summary>
    /// Meal.
    /// </summary>
    [Serializable]
    public class Meal
    {
        /// <summary>
        /// Time of meal.
        /// </summary>
        public DateTime MealTime { get; }

        /// <summary>
        /// Foods in meal in grams.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// User that had a meal.
        /// </summary>
        public User User { get; }

        public Meal(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty or null", nameof(user));
            MealTime = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
