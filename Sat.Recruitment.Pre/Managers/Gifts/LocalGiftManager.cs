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
    using static Sat.Recruitment.Pre.Setup;

    /// <summary>
    /// Represents a local gift manager evaluator.
    /// </summary>
    internal class LocalGiftManager : IGiftManager
    {
        private readonly ILogger logger;

        private readonly ServiceResolver serviceResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalGiftManager"/> class.
        /// </summary>
        /// <param name="logger">Logs instance.</param>
        /// <param name="serviceResolver">Service resolver for the gift evaluator.</param>
        public LocalGiftManager(ILogger<LocalGiftManager> logger, ServiceResolver serviceResolver)
        {
            Ensure.Any.IsNotNull(logger);
            Ensure.Any.IsNotNull(serviceResolver);

            this.logger = logger;
            this.serviceResolver = serviceResolver;
        }

        /// <inheritdoc/>
        public Task<decimal> GetMoneyAsync(UserType type, decimal money)
        {
            var service = this.serviceResolver.Invoke(type);
            if (service != null)
            {
                return Task.FromResult(service.Calculate(money));
            }

            var errorMessage = string.Format("The user type {0} has not been registered in the promotions.", type.ToString());
            this.logger.LogError(errorMessage);

            throw new Exception(errorMessage);
        }
    }
}
