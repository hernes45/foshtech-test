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
        /// <summary>
        /// Delegate for the giftmanager.
        /// </summary>
        /// <param name="type">User type.</param>
        /// <returns>Gift process.</returns>
        internal delegate IGiftProcess ServiceResolver(UserType type);

        /// <inheritdoc/>
        public override void Install(IServiceCollection serviceCollection)
        {
            base.Install(serviceCollection);

            serviceCollection.AddTransient<IUserManager, UserManager>();
            serviceCollection.AddTransient<IGiftManager, LocalGiftManager>();
            serviceCollection.AddTransient<NormalGiftProcess>();
            serviceCollection.AddTransient<PremiumGiftProcess>();
            serviceCollection.AddTransient<SuperUserGiftProcess>();
            serviceCollection.AddTransient<IGiftService, GiftService>();
            serviceCollection.AddTransient<ServiceResolver>(serviceProvider => type =>
            {
                switch (type)
                {
                    case UserType.Normal:
                        return serviceProvider.GetService<NormalGiftProcess>();
                    case UserType.Premium:
                        return serviceProvider.GetService<PremiumGiftProcess>();
                    case UserType.SuperUser:
                        return serviceProvider.GetService<SuperUserGiftProcess>();
                    default:
                        return null;
                }
            });
        }
    }
}
