// <copyright file="UserManager.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Sat.Recruitment.Dom.Common;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Dom.Repositories;
    using Sat.Recruitment.Pre.Model;
    using Sat.Recruitment.Pre.Services;

    /// <inheritdoc/>
    internal class UserManager : IUserManager
    {
        private readonly IGiftService giftService;

        private readonly IUserRepository userRepository;

        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="giftService">Implementation of the gift service.</param>
        /// <param name="userRepository">User repository.</param>
        /// <param name="logger">logger.</param>
        public UserManager(IGiftService giftService, IUserRepository userRepository, ILogger logger)
        {
            // todo añadir ensures
            this.giftService = giftService;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task CreateAsync(UserViewModel user)
        {
            this.logger.LogTrace("[UserManager/CreateAsync] Creating user: {0}", user.Name);

            var newUser = new User();
            newUser.Address = user.Address;
            newUser.Name = user.Name;
            newUser.Phone = user.Phone;
            newUser.UserType = (UserType)user.UserType;
            newUser.Money = await this.giftService.GetMoneyNewUserAsync(user.Money, (UserType)user.UserType).ConfigureAwait(false);
            newUser.Email = UserTools.NormalizeEmail(newUser.Email);

            if (await this.ValidateInsert(newUser).ConfigureAwait(false))
            {
                await this.userRepository.AddAsync(newUser);
            }
            else
            {
                this.logger.LogError("[UserManager/CreateAsync] Duplicated user: {0}", user.Name);

                throw new Exception("Usuario duplicado");
            }
        }

        /// <summary>
        /// Validates the domain model to insert.
        /// </summary>
        /// <param name="user">Instance of the user.</param>
        /// <returns>True if it is ok.</returns>
        public async Task<bool> ValidateInsert(User user)
        {
            var result = await this.userRepository.FindAsync((item) => !(item.Email == user.Email || item.Phone == user.Phone) && !(user.Name == item.Name && user.Address == item.Address));

            return result.Any();
        }
    }
}
