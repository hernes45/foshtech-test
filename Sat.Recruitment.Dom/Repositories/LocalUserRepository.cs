// <copyright file="IUserRepository.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Dom.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Sat.Recruitment.Dom.Model;

    /// <summary>
    /// Repository of users.
    /// </summary>
    public class LocalUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalUserRepository"/> class.
        /// </summary>
        public LocalUserRepository()
        {
            this.InitializeList();
        }

        /// <summary>
        /// Gets the list of users. For testing.
        /// </summary>
        internal List<User> Users
        {
            get
            {
                return this.users;
            }
        }

        /// <summary>
        /// Add a new user in the repository.
        /// </summary>
        /// <param name="user">Instance of the new user to be added.</param>
        /// <returns>Void if OK. Exception in case of error.</returns>
        public Task AddAsync(User user)
        {
            this.users.Add(user);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Returns a list of user that fits the filter.
        /// </summary>
        /// <param name="filter">filter of the user repository.</param>
        /// <returns>Collection of users.</returns>
        public Task<IEnumerable<User>> FindAsync(Func<User, bool> filter)
        {
            return Task.FromResult(this.users.Where(user => filter.Invoke(user)));
        }

        private void InitializeList()
        {
            // I Assume that the file is only for the test, the idea is to connect to the sources using the settings.
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLineAsync().Result;
                        var user = new User
                        {
                            Name = line.Split(',')[0].ToString(),
                            Email = line.Split(',')[1].ToString(),
                            Phone = line.Split(',')[2].ToString(),
                            Address = line.Split(',')[3].ToString(),
                            UserType = (UserType)Enum.Parse(typeof(UserType), line.Split(',')[4].ToString()),
                            Money = decimal.Parse(line.Split(',')[5].ToString()),
                        };

                        this.users.Add(user);
                    }
                }
            }
        }
    }
}
