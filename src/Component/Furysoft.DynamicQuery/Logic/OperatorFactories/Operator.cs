// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operator.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Logic.OperatorFactories
{
    using Entities.Nodes;
    using Entities.Operations;

    /// <summary>
    /// The Operator Factory
    /// </summary>
    public static class Operator
    {
        /// <summary>
        /// Returns a Binary node of the AND of the two statements
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="BinaryNode"/></returns>
        public static BinaryNode And(Node left, Node right)
        {
            return new BinaryNode
            {
                Statement = $"{left.Statement} and {right.Statement}",
                Name = null,
                LeftNode = left,
                RightNode = right,
                Conjunctive = Conjunctives.And
            };
        }

        /// <summary>
        /// Returns a Binary node of the OR of the two statements
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The <see cref="BinaryNode"/></returns>
        public static BinaryNode Or(Node left, Node right)
        {
            return new BinaryNode
            {
                Statement = $"{left.Statement} or {right.Statement}",
                Name = null,
                LeftNode = left,
                RightNode = right,
                Conjunctive = Conjunctives.Or
            };
        }

        /// <summary>
        /// Returns an Equals operator for matching a string
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="EqualsOperator"/></returns>
        public static EqualsOperator Equals(string name, object value)
        {
            return new EqualsOperator
            {
                Statement = $"{name}:{value}",
                Name = name,
                Value = value,
                IsNot = false,
                CaseInsensitive = false
            };
        }
    }
}