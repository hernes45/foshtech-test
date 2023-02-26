// <copyright file="User.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Dom.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the User DTO.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the address of the user.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone of the user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Gets or sets the money of the user.
        /// </summary>
        public decimal Money { get; set; }
    }
}
