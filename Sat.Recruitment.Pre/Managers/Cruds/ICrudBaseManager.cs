// <copyright file="ICrudBaseManager.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base of the CRUDs.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface ICrudBaseManager<T>
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">Instance of the domain model entity.</param>
        /// <returns>Void task. If there is an error the method throws an exception.</returns>
        Task CreateAsync(T entity);
    }
}
