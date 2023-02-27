// <copyright file="Setup.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Pre.Managers;
    using Sat.Recruitment.Pre.Services;
    using domSetup = Sat.Recruitment.Dom.Common.Setup;

    /// <inheritdoc/>
    public class Setup : domSetup
    {
        /// <inheritdoc/>
        public override void Install(IServiceCollection serviceCollection)
        {
            base.Install(serviceCollection);

            serviceCollection.AddTransient<IUserManager, UserManager>();
            serviceCollection.AddTransient<IGiftManager, LocalGiftManager>();
            serviceCollection.AddTransient<IGiftService, GiftService>();
        }
    }
}
