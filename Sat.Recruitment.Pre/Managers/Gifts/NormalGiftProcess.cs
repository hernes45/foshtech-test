// <copyright file="NormalGiftProcess.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///  Evaluates the gift for normal users.
    /// </summary>
    internal class NormalGiftProcess : IGiftProcess
    {
        /// <inheritdoc/>
        public decimal Calculate(decimal money)
        {
            if (money > 100)
            {
                return money * new decimal(1.12);
            }
            else if (money > 10)
            {
                return money * new decimal(1.08);
            }

            return money;
        }
    }
}
