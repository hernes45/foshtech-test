// <copyright file="IUserManager.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Sat.Recruitment.Pre.Model;

    /// <summary>
    /// Represents the User manager.
    /// Managers handles all the implementations of the entities.
    /// </summary>
    public interface IUserManager : ICrudBaseManager<UserViewModel>
    {
    }
}
