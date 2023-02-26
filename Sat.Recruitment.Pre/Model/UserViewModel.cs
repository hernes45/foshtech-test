// <copyright file="UserViewModel.cs" company="Fosh-Tech">
// Copyright (c) Fosh-Tech. All rights reserved.
// </copyright>

namespace Sat.Recruitment.Pre.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents de View Model of a User.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the address of the user.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone of the user.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        public UserViewModelType UserType { get; set; }

        /// <summary>
        /// Gets or sets the money of the user.
        /// </summary>
        public decimal Money { get; set; }
    }
}
