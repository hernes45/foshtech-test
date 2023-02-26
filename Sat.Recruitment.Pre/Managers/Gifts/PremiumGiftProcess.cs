// <copyright file="PremiumGiftProcess.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///  Evaluates the gift for premium users.
    /// </summary>
    internal class PremiumGiftProcess : IGiftProcess
    {
        /// <inheritdoc/>
        public decimal Calculate(decimal money)
        {
            if (money > 100)
            {
                return money * 2;
            }

            return money;
        }
    }
}
