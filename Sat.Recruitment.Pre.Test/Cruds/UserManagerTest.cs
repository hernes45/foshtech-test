// <copyright file="UserManagerTest.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Test
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Dom.Repositories;
    using Sat.Recruitment.Pre.Managers;
    using Sat.Recruitment.Pre.Model;
    using Sat.Recruitment.Pre.Services;
    using Xunit;

    /// <summary>
    /// Test of the user manager.
    /// </summary>
    [CollectionDefinition("UserManager", DisableParallelization = true)]
    public class UserManagerTest
    {
        /// <summary>
        /// Create user test.
        /// </summary>
        [Fact]
        public async void CreateUserValidUser()
        {
            var giftService = new Mock<IGiftService>();
            giftService.Setup(service => service.GetMoneyNewUserAsync(It.IsAny<decimal>(), It.IsAny<UserType>()))
                .Returns(Task.FromResult(new decimal(900)));
            var repository = new Mock<IUserRepository>();
            repository.Setup(repo => repo.FindAsync(It.IsAny<Func<User, bool>>()))
                .Returns(Task.FromResult((IEnumerable<User>)new List<User>()));
            repository.Setup(repo => repo.AddAsync(It.IsAny<User>()))
                .Callback((User user) =>
                {
                    Assert.Equal(900, user.Money);
                });

            var logger = new Mock<ILogger<UserManager>>();
            var manager = new UserManager(giftService.Object, repository.Object, logger.Object);

            var newUser = new UserViewModel();
            newUser.Name = "Mike";
            newUser.Email = "mike@gmail.com";
            newUser.Address = "Av. Juan G";
            newUser.Phone = "+349 1122354215";
            newUser.UserType = UserViewModelType.Normal;
            newUser.Money = 124;

            await manager.CreateAsync(newUser);

            repository.VerifyAll();
            giftService.VerifyAll();
        }

        /// <summary>
        /// Create with no valid user test.
        /// </summary>
        [Fact]
        public async void CreateUserNoValidUser()
        {
            var giftService = new Mock<IGiftService>();
            var repository = new Mock<IUserRepository>();
            repository.Setup(repo => repo.FindAsync(It.IsAny<Func<User, bool>>()))
                .Returns(Task.FromResult((IEnumerable<User>)new List<User>() { new User() }));
            var logger = new Mock<ILogger<UserManager>>();
            var manager = new UserManager(giftService.Object, repository.Object, logger.Object);

            var newUser = new UserViewModel();
            newUser.Name = "Mike";
            newUser.Email = "mike@gmail.com";
            newUser.Address = "Av. Juan G";
            newUser.Phone = "+349 1122354215";
            newUser.UserType = UserViewModelType.Normal;
            newUser.Money = 124;

            var exception = await Assert.ThrowsAsync<Exception>(() => manager.CreateAsync(newUser));
            Assert.Equal("Usuario duplicado", exception.Message);
        }
    }
}
