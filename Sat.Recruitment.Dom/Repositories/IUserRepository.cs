// <copyright file="IUserRepository.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Dom.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using Sat.Recruitment.Dom.Model;

    /// <summary>
    /// Repository of users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Add a new user in the repository.
        /// </summary>
        /// <param name="user">Instance of the new user to be added.</param>
        /// <returns>Void if OK. Exception in case of error.</returns>
        Task AddAsync(User user);

        /// <summary>
        /// Returns a list of user that fits the filter.
        /// </summary>
        /// <param name="filter">filter of the user repository.</param>
        /// <returns>Collection of users.</returns>
        Task<Collection<User>> FindAsync(Func<User, bool> filter);
    }
}
