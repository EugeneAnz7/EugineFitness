using EugineFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EugineFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        /// <summary>
        /// Create new exercise controller for this user.
        /// </summary>
        /// <param name="user"></param>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty or null", nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime start, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exersise = new Exercise(start, end, activity, user);
                Exercises.Add(exersise);
            }
            else
            {
                var exersise = new Exercise(start, end, act, user);
                Exercises.Add(exersise);
            }
            Save();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
