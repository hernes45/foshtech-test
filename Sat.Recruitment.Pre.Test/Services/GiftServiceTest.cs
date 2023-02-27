// <copyright file="GiftServiceTest.cs" company="Fosh-Tech">
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
    [CollectionDefinition("GiftServiceTest", DisableParallelization = true)]
    public class GiftServiceTest
    {
        /// <summary>
        /// Check constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            var manager = new Mock<IGiftManager>();
            var service = new GiftService(manager.Object);

            Assert.NotNull(service);
        }

        /// <summary>
        /// Check Normal.
        /// </summary>
        [Fact]
        public async void GetMoneyAsyncTest()
        {
            var manager = new Mock<IGiftManager>();
            manager.Setup(manager => manager.GetMoneyAsync(It.IsAny<UserType>(), It.IsAny<decimal>()))
                .Returns(Task.FromResult(new decimal(100)));

            var service = new GiftService(manager.Object);
            var result = await service.GetMoneyNewUserAsync(100, UserType.Normal).ConfigureAwait(false);

            Assert.Equal(100, result);
        }
    }
}
