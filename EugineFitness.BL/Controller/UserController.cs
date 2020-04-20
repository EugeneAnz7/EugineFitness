﻿using EugineFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace EugineFitness.BL.Controller
{
    /// <summary>
    ///  User controller.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// User.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new controller
        /// </summary>
        /// <param name="user"> User. </param>
        public UserController(string userName)
        {

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName can't be empty or null", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Load users list.
        /// </summary>
        /// <returns> User. </returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Check
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}
