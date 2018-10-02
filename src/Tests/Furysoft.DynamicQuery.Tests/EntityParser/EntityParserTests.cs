// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityParserTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.EntityParser
{
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using Attributes;
    using NUnit.Framework;
    using Parsers;

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

            Assert.That(permittedProperties.Count, Is.EqualTo(3));

            Assert.That(permittedProperties.Contains("PropertyOne"), Is.True);
            Assert.That(permittedProperties.Contains("property_three"), Is.True);
            Assert.That(permittedProperties.Contains("property_four"), Is.True);
            Assert.That(permittedProperties.Contains("PropertyTwo"), Is.False);
        }

        /// <summary>
        /// Determines whether [is permitted when name provided expect correct value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is permitted when name provided expect correct value] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        [TestCase("PropertyOne", ExpectedResult = true)]
        [TestCase("PropertyTwo", ExpectedResult = false)]
        [TestCase("PropertyThree", ExpectedResult = false)]
        [TestCase("property_three", ExpectedResult = true)]
        [TestCase("property_four", ExpectedResult = true)]
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

#pragma warning disable SA1402 // File may only contain a single class
                              /// <summary>
                              /// The Test Entity
                              /// </summary>
    public sealed class TestEntity
#pragma warning restore SA1402 // File may only contain a single class
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
    }
}