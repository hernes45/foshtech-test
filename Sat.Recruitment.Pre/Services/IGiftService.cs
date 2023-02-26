// <copyright file="IGiftService.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Pre.Model;

    /// <summary>
    /// Service that handles the operations for the gifts.
    /// </summary>
    public interface IGiftService
    {
        /// <summary>
        /// Gets the money with the gift for new users.
        /// </summary>
        /// <param name="money">Money.</param>
        /// <param name="type">Type of user.</param>
        /// <returns>Amount of money with the new user promotion.</returns>
        Task<decimal> GetMoneyNewUserAsync(decimal money, UserType type);
    }
}
