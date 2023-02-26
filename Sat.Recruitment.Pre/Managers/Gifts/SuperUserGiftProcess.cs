// <copyright file="SuperUserGiftProcess.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///  Evaluates the gift for super users.
    /// </summary>
    internal class SuperUserGiftProcess : IGiftProcess
    {
        /// <inheritdoc/>
        public decimal Calculate(decimal money)
        {
            if (money > 100)
            {
                return money * new decimal(1.20);
            }

            return money;
        }
    }
}
