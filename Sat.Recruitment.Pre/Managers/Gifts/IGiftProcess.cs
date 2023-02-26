// <copyright file="IGiftProcess.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the process of the estimation of the promotion.
    /// </summary>
    public interface IGiftProcess
    {
        /// <summary>
        /// Calculates the money with promotion.
        /// </summary>
        /// <param name="money">Base money.</param>
        /// <returns>Money with promotion.</returns>
        decimal Calculate(decimal money);
    }
}
