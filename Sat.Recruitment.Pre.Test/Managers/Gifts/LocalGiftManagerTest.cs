// <copyright file="LocalGiftManagerTest.cs" company="Fosh-Tech">
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
    [CollectionDefinition("LocalGiftManagerTest", DisableParallelization = true)]
    public class LocalGiftManagerTest
    {
        /// <summary>
        /// Check constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            Assert.NotNull(manager);
        }

        /// <summary>
        /// Check Normal.
        /// </summary>
        [Fact]
        public async void GetMoneyNormalBigger100Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.Normal, 101).ConfigureAwait(false);

            Assert.Equal(new decimal(113.12), result);
        }

        /// <summary>
        /// Check normal bigger than 10.
        /// </summary>
        [Fact]
        public async void GetMoneyBigger10Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.Normal, 100).ConfigureAwait(false);

            Assert.Equal(108, result);
        }

        /// <summary>
        /// Check normal lower than 10.
        /// </summary>
        [Fact]
        public async void GetMoneyLower10Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.Normal, 5).ConfigureAwait(false);

            Assert.Equal(5, result);
        }

        /// <summary>
        /// Check Premium bigger than 100.
        /// </summary>
        [Fact]
        public async void GetMoneyPremiumBigger100Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.Premium, 101).ConfigureAwait(false);

            Assert.Equal(202, result);
        }

        /// <summary>
        /// Check Premium bigger than 100.
        /// </summary>
        [Fact]
        public async void GetMoneyPremiumLower100Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.Premium, 90).ConfigureAwait(false);

            Assert.Equal(90, result);
        }

        /// <summary>
        /// Check Premium bigger than 100.
        /// </summary>
        [Fact]
        public async void GetMoneySuperUserBigger100Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.SuperUser, 101).ConfigureAwait(false);

            Assert.Equal(new decimal(121.2), result);
        }

        /// <summary>
        /// Check Premium bigger than 100.
        /// </summary>
        [Fact]
        public async void GetMoneySuperUserLower100Async()
        {
            var logger = new Mock<ILogger<LocalGiftManager>>();
            var manager = new LocalGiftManager(logger.Object);

            var result = await manager.GetMoneyAsync(UserType.Premium, 90).ConfigureAwait(false);

            Assert.Equal(new decimal(90), result);
        }
    }
}
