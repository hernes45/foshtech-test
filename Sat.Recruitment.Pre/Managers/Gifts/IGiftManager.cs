// <copyright file="IGiftManager.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Sat.Recruitment.Dom.Model;

    /// <summary>
    /// Manager for the gif promotions.
    /// </summary>
    public interface IGiftManager
    {
        /// <summary>
        /// Calculates the money with the promotion given a user type.
        /// </summary>
        /// <param name="type">User type.</param>
        /// <param name="money">Base money.</param>
        /// <returns>Money with promotion.</returns>
        Task<decimal> GetMoneyAsync(UserType type, decimal money);
    }
}
