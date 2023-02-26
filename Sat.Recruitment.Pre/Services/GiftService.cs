// <copyright file="GiftService.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EnsureThat;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Pre.Managers;
    using Sat.Recruitment.Pre.Model;

    /// <inheritdoc/>
    public class GiftService : IGiftService
    {
        private readonly IGiftManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftService"/> class.
        /// </summary>
        /// <param name="manager">The gift manager.</param>
        public GiftService(IGiftManager manager)
        {
            Ensure.Any.IsNotNull(manager);

            this.manager = manager;
        }

        /// <inheritdoc/>
        public Task<decimal> GetMoneyNewUserAsync(decimal money, UserType type)
        {
            return this.manager.GetMoneyAsync(type, money);
        }
    }
}
