// <copyright file="UsersController.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using EnsureThat;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sat.Recruitment.Pre.Managers;
    using Sat.Recruitment.Pre.Model;

    /// <summary>
    /// Represents the Rest API for Users.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;

        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userManager">Instance of the manager.</param>
        /// <param name="logger">Instace of the logger.</param>
        public UsersController(IUserManager userManager, ILogger<UsersController> logger)
        {
            Ensure.Any.IsNotNull(userManager);
            Ensure.Any.IsNotNull(logger);

            this.userManager = userManager;
            this.logger = logger;
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="user">View model of the user.</param>
        /// <returns>Return an action result.</returns>
        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> CreateUser(UserViewModel user)
        {
            Ensure.Any.IsNotNull(user);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this.userManager.CreateAsync(user);

                return this.Ok();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "POST /create-user {@user}", user);
                throw;
            }
        }
    }
}
