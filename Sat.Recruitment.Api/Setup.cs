// <copyright file="Setup.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using preSetup = Sat.Recruitment.Pre.Setup;

    /// <inheritdoc/>
    public class Setup : preSetup
    {
        /// <inheritdoc/>
        public override void Install(IServiceCollection serviceCollection)
        {
            base.Install(serviceCollection);
        }
    }
}
