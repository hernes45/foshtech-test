// <copyright file="UnitTest1.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Test
{
    using System;
    using System.Dynamic;
    using Microsoft.AspNetCore.Mvc;
    using Sat.Recruitment.Api.Controllers;
    using Xunit;

    /// <summary>
    /// Unit test for the User Controller.
    /// </summary>
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        /// <summary>
        /// Test 1.
        /// </summary>
        [Fact]
        public void Test1()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        /// <summary>
        /// Test 2.
        /// </summary>
        [Fact]
        public void Test2()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }
    }
}
