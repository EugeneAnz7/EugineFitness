﻿using EugineFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace EugineFitness.BL.Controller
{
    public class MealController : ControllerBase
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Meal Meal { get; }

        public MealController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty or null.", nameof(user));

            Foods = GetAllFoods();
            Meal = GetMeal();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Load meals list.
        /// </summary>
        /// <returns></returns>
        private Meal GetMeal()
        {
            return Load<Meal>().FirstOrDefault() ?? new Meal(user);
        }

        /// <summary>
        /// Load foods list.
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Meal>() { Meal });
        }
    }
}
