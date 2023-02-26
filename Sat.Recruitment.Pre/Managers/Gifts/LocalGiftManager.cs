// <copyright file="LocalGiftManager.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EnsureThat;
    using Microsoft.Extensions.Logging;
    using Sat.Recruitment.Dom.Model;

    /// <summary>
    /// Represents a local gift manager evaluator.
    /// </summary>
    internal class LocalGiftManager : IGiftManager
    {
        private readonly ILogger logger;

        private readonly Dictionary<UserType, IGiftProcess> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalGiftManager"/> class.
        /// </summary>
        /// <param name="logger">Logs instance.</param>
        public LocalGiftManager(ILogger logger)
        {
            Ensure.Any.IsNotNull(logger);

            this.logger = logger;
            this.dictionary = new Dictionary<UserType, IGiftProcess>();
        }

        /// <inheritdoc/>
        public Task<decimal> GetMoneyAsync(UserType type, decimal money)
        {
            if (this.dictionary.ContainsKey(type))
            {
                return Task.FromResult(this.dictionary[type].Calculate(money));
            }

            var errorMessage = string.Format("The user type {0} has not been registered in the promotions.", type.ToString());
            this.logger.LogError(errorMessage);

            throw new Exception(errorMessage);
        }
    }
}
