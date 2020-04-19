using EugineFitness.BL.Controller;
using EugineFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace EugineFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("EugineFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterUsername", culture));
            var name = Console.ReadLine();


            var userController = new UserController(name);
            var mealController = new MealController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your Gender.");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want?");
            Console.WriteLine("E - enter a meal");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterMeal();
                mealController.Add(foods.Food, foods.Weight);

                foreach(var item in mealController.Meal.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterMeal()
        {
            Console.WriteLine("Enter product name.");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var weight = ParseDouble("weight of portion");

            var product = new Food(food,calories, proteins, fats, carbohydrates);


            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter your birthday date (dd.mm.yyyy).");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthdate))
                {
                    birthDate = birthdate;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}.");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                }
            }
        }
    }
}
