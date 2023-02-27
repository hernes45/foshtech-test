// <copyright file="UserToolsTest.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Test
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using Sat.Recruitment.Dom.Common;
    using Sat.Recruitment.Dom.Model;
    using Sat.Recruitment.Dom.Repositories;
    using Xunit;

    /// <summary>
    /// Unit test for the repository local.
    /// </summary>
    [CollectionDefinition("UserToolsTest", DisableParallelization = true)]
    public class UserToolsTest
    {
        /// <summary>
        /// Verify the load of the test file.
        /// </summary>
        [Fact]
        public void NormalizeEmailRegular()
        {
            var email = "hernes45.test@gmail.com";
            var result = UserTools.NormalizeEmail(email);

            Assert.Equal("hernes45test@gmail.com", result);
        }

        /// <summary>
        /// Verify the load of the test file.
        /// </summary>
        [Fact]
        public void NormalizeSuffixRegular()
        {
            var email = "hernes45.test+suffix@gmail.com";
            var result = UserTools.NormalizeEmail(email);

            Assert.Equal("hernes45testsuffix@gmail.com", result);
        }
    }
}
