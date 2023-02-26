// <copyright file="UnitTest1.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Test
{
    using System;
    using System.Dynamic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Sat.Recruitment.Api.Controllers;
    using Sat.Recruitment.Pre.Managers;
    using Sat.Recruitment.Pre.Model;
    using Xunit;

    /// <summary>
    /// Unit test for the User Controller.
    /// </summary>
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTest
    {
        /// <summary>
        /// Test 1.
        /// </summary>
        [Fact]
        public void CreateUserValid()
        {
            var userManager = new Mock<IUserManager>();
            userManager.Setup(manager => manager.CreateAsync(It.IsAny<UserViewModel>()))
                .Returns(Task.CompletedTask);

            var logger = new Mock<ILogger<UsersController>>();

            var userController = new UsersController(userManager.Object, logger.Object);
            var newUser = new UserViewModel();
            newUser.Name = "Mike";
            newUser.Email = "mike@gmail.com";
            newUser.Address = "Av. Juan G";
            newUser.Phone = "+349 1122354215";
            newUser.UserType = UserViewModelType.Normal;
            newUser.Money = 124;

            var result = userController.CreateUser(newUser).Result;

            userManager.VerifyAll();

            Assert.IsType<OkResult>(result);
        }

        /// <summary>
        /// Test 2.
        /// </summary>
        [Fact]
        public void CreateUserNoValid()
        {
            var userManager = new Mock<IUserManager>();
            userManager.Setup(manager => manager.CreateAsync(It.IsAny<UserViewModel>()))
                .Throws(() => new Exception("test exception"));

            var logger = new Mock<ILogger<UsersController>>();

            var userController = new UsersController(userManager.Object, logger.Object);
            var newUser = new UserViewModel();
            newUser.Name = "Agustina";
            newUser.Email = "Agustina@gmail.com";
            newUser.Address = "Av. Juan G";
            newUser.Phone = "+349 1122354215";
            newUser.UserType = UserViewModelType.Normal;
            newUser.Money = 124;

            var result = userController.CreateUser(newUser).Result;

            userManager.VerifyAll();

            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }

        /// <summary>
        /// Test 2.
        /// </summary>
        [Fact]
        public void CreateUserBarRequest()
        {
            var userManager = new Mock<IUserManager>();
            var logger = new Mock<ILogger<UsersController>>();

            var userController = new UsersController(userManager.Object, logger.Object);
            userController.ModelState.AddModelError("Name", "Required");
            var newUser = new UserViewModel();
            newUser.Name = null;
            newUser.Email = "Agustina@gmail.com";
            newUser.Address = "Av. Juan G";
            newUser.Phone = "+349 1122354215";
            newUser.UserType = UserViewModelType.Normal;
            newUser.Money = 124;

            var result = userController.CreateUser(newUser).Result;

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
