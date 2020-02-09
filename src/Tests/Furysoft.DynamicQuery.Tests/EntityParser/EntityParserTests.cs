// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.EntityParser
{
    using Attributes;
    using Furysoft.DynamicQuery.Entities.Parsers;
    using NUnit.Framework;
    using Parsers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using DeepEqual.Syntax;

    /// <summary>
    /// The Entity Parser Tests
    /// </summary>
    [TestFixture]
    public sealed class EntityParserTests : TestBase
    {
        /// <summary>
        /// Gets the properties when entity with attributes expect permitted names.
        /// </summary>
        [Test]
        public void GetProperties_WhenEntityWithAttributes_ExpectPermittedNames()
        {
            // Arrange
            var entityParser = new EntityParser<TestEntity>();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var permittedProperties = entityParser.PermittedProperties;
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(permittedProperties, Is.Not.Null);

            var expected = new List<EntityProperty>
            {
                new EntityProperty { InternalName = "PropertyFour", QueryName = "property_four", IsPermitted = true },
                new EntityProperty { InternalName = "PropertyOne", QueryName = "PropertyOne", IsPermitted = true },
                new EntityProperty { InternalName = "PropertyThree", QueryName = "property_three", IsPermitted = true }
            };

            permittedProperties.ShouldDeepEqual(expected);
        }

        /// <summary>
        /// Determines whether [is permitted when name provided expect correct value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is permitted when name provided expect correct value] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        [Test]
        [TestCase("PropertyOne", ExpectedResult = true, Description = "PropertyOne should be isPermitted")]
        [TestCase("PropertyTwo", ExpectedResult = false, Description = "PropertyTwo should NOT be isPermitted")]
        [TestCase("PropertyThree", ExpectedResult = true, Description = "PropertyThree should be isPermitted")]
        [TestCase("property_three", ExpectedResult = true, Description = "property_three should be isPermitted")]
        [TestCase("property_four", ExpectedResult = true, Description = "property_four should be isPermitted")]
        public bool IsPermitted_WhenNameProvided_ExpectCorrectValue(string value)
        {
            // Arrange
            var entityParser = new EntityParser<TestEntity>();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var isPermitted = entityParser.IsPermitted(value);
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            return isPermitted;
        }
    }

    // ReSharper disable UnusedMember.Global
#pragma warning disable SA1402 // File may only contain a single class

    /// <summary>
    /// The Test Entity
    /// </summary>
    public sealed class TestEntity
    {
        /// <summary>Gets or sets the property four.</summary>
        [DataMember(Name = "property_four")]
        public string PropertyFour { get; set; }

        /// <summary>Gets or sets the property one.</summary>
        public string PropertyOne { get; set; }

        /// <summary>Gets or sets the property three.</summary>
        [Name("property_three")]
        public string PropertyThree { get; set; }

        /// <summary>Gets or sets the property two.</summary>
        [Exclude]
        public string PropertyTwo { get; set; }

        // ReSharper restore UnusedMember.Global
#pragma warning restore SA1402 // File may only contain a single class
    }
}