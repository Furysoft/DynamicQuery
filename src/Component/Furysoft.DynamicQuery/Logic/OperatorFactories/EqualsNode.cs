// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsNode.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.OperatorFactories
{
    using Furysoft.DynamicQuery.Entities.Operations;

    /// <summary>
    /// The Equals Node Factory.
    /// </summary>
    public static class EqualsNode
    {
        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="EqualsOperator"/>.</returns>
        public static EqualsOperator CreateEquals(string name, string value)
        {
            return new EqualsOperator
            {
                Statement = $"{name}:{value}",
                Value = value,
                Name = name,
                IsNot = false,
            };
        }

        /// <summary>
        /// Creates the not equals.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="EqualsOperator"/>.</returns>
        public static EqualsOperator CreateNotEquals(string name, string value)
        {
            return new EqualsOperator
            {
                Statement = $"{name}:!{value}",
                Value = value,
                Name = name,
                IsNot = true,
            };
        }
    }
}