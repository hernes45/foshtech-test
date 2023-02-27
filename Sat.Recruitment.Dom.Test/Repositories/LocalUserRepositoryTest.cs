// <copyright file="LocalUserRepositoryTest.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Test
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Dom.Repositories;
    using Xunit;

    /// <summary>
    /// Unit test for the repository local.
    /// </summary>
    [CollectionDefinition("LocalUserRepositoryTest", DisableParallelization = true)]
    public class LocalUserRepositoryTest
    {
        /// <summary>
        /// Verify the load of the test file.
        /// </summary>
        [Fact]
        public void Initialize()
        {
            var repository = new LocalUserRepository();

            Assert.NotNull(repository);
            Assert.Equal(3, repository.Users.Count);
            Assert.Equal("Juan", repository.Users[0].Name);
            Assert.Equal("Franco", repository.Users[1].Name);
            Assert.Equal("Agustina", repository.Users[2].Name);

            // TODO : check the rest of properties.
        }

        /// <summary>
        /// Verify the load of the test file.
        /// </summary>
        [Fact]
        public async void Add()
        {
            var repository = new LocalUserRepository();
            await repository.AddAsync(new User() { Name = "PRUEBA_NAME" }).ConfigureAwait(false);

            Assert.NotNull(repository);
            Assert.Equal(4, repository.Users.Count);
            Assert.Equal("PRUEBA_NAME", repository.Users[3].Name);

            // TODO : check the rest of properties.
        }

        /// <summary>
        /// Verify the load of the test file.
        /// </summary>
        [Fact]
        public async void Find()
        {
            var repository = new LocalUserRepository();
            var finded = await repository.FindAsync((user) => user.Name == "Juan").ConfigureAwait(false);

            Assert.NotNull(repository);
            Assert.Single(finded);
            Assert.Equal("Juan", finded.Single().Name);

            // TODO : check the rest of properties.
        }
    }
}
