// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEntity.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Integration.TestHelpers
{
    using System;

    /// <summary>
    /// The Test Entity
    /// </summary>
    public sealed class TestEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}