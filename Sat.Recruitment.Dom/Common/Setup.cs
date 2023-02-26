// <copyright file="Setup.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Dom.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using Sat.Recruitment.Dom.Repositories;

    /// <summary>
    /// Represents the service registration.
    /// </summary>
    public class Setup
    {
        /// <summary>
        /// Place to register the interfaces and implementations.
        /// </summary>
        /// <param name="serviceCollection">Service collections.</param>
        public virtual void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUserRepository, LocalUserRepository>();
        }
    }
}
