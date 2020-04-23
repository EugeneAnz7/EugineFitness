using EugineFitness.BL.Model;
using System.Data.Entity;

namespace EugineFitness.BL.Controller
{
    /// <summary>
    /// Context for DataBase
    /// </summary>
    class FitnessContext : DbContext
    {
        public FitnessContext() : base("DbConnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
