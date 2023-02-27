// <copyright file="UserTools.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Dom.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EnsureThat;

    /// <summary>
    /// Generic pourpose tools.
    /// </summary>
    public static class UserTools
    {
        /// <summary>
        /// Returns the normalized email.
        /// </summary>
        /// <param name="email">input email.</param>
        /// <returns>Normalized email.</returns>
        public static string NormalizeEmail(string email)
        {
            Ensure.String.IsNotNullOrWhiteSpace(email);

            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", string.Empty) : aux[0].Replace(".", string.Empty).Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
