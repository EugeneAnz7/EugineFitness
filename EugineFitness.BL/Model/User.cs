using System;
using System.Collections.Generic;

namespace EugineFitness.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Birthday date
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }  // Incorrect.
        #endregion

        public User() { }
        
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="gender"> Gender. </param>
        /// <param name="birthDate"> Birthday Date. </param>
        /// <param name="weight"> Weight. </param>
        /// <param name="height"> Height. </param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Check arguments
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username can't be empty or null.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender can't be null.", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Unreal birthday date.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException("Weight can't be less 0.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Height can't be less 0.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username can't be empty or null.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+ " " + Age;
        }
    }
}
