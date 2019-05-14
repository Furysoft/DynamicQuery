// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereSplitterTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.Splitters
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    /// <summary>
    /// The Where Splitter Tests
    /// </summary>
    [TestFixture]
    public sealed class WhereSplitterTests : TestBase
    {
        private static readonly Regex RegexTest = new Regex("(and|or)");

        /// <summary>
        /// Does this instance.
        /// </summary>
        [Test]
        public void Do()
        {
            var testString1 = "test1:value and (test2:value or test3:value)";

            var brackets = ParseBrackets(testString1);
        }

        /// <summary>
        /// Does the stuff.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>
        /// The <see cref="Node" />
        /// </returns>
        private static Node ParseBrackets(string data)
        {
            var leftBracketIndex = -1; // The index of the currently processed left bracket.
            var bracketDepth = 0; // The number of brackets deep we are currently

            var children = new List<Node>();
            for (var i = 0; i < data.Length; i++)
            {
                /*
                 * Find any instances of brackets.
                 * If a bracket is found mark the start location.
                 * When the matching close bracket is found, take the data between the brackets and recurse.
                 */

                if (data[i] == '(')
                {
                    if (leftBracketIndex == -1)
                    {
                        leftBracketIndex = i;
                    }

                    bracketDepth++;
                }

                /*
                 * When we find a right bracket, we reduce the depth count.
                 * If the depth count is 0 after this, it means we have found the right bracket that corresponds
                 * to the previous left bracket
                 */

                if (data[i] == ')')
                {
                    bracketDepth--;

                    if (bracketDepth == 0)
                    {
                        // The current sub query is the bit between the left index and the current index.
                        var subQuery = data.Substring(leftBracketIndex + 1, i - leftBracketIndex - 1);

                        var doStuff = ParseBrackets(subQuery);
                        children.Add(doStuff);

                        // Reset the leftBracket Index so that we can find any more bracket pairs at this level
                        leftBracketIndex = -1;
                    }
                }
            }

            if (!children.Any())
            {
                return ParseStatement(data);
            }

            return new TreeNode
            {
                Children = children
            };
        }

        /// <summary>
        /// Handles the split.
        /// </summary>
        /// <param name="stringPart">The string part.</param>
        /// <returns>
        /// The <see cref="Node" />
        /// </returns>
        private static Node ParseStatement(string stringPart)
        {
            var strings = RegexTest.Split(stringPart, 2).ToList();

            // If there's only 1, we're done. No need to parse more!
            if (strings.Count == 1)
            {
                return new UnaryNode { Data = strings[0] };
            }

            return new BinaryNode
            {
                Left = ParseStatement(strings[0]),
                Conjunctive = strings[1],
                Right = ParseStatement(strings[2])
            };
        }

        /// <summary>
        /// The Leaf Node
        /// </summary>
        private class BinaryNode : Node
        {
            /// <summary>
            /// Gets or sets the conjunctive.
            /// </summary>
            public string Conjunctive { get; set; }

            /// <summary>
            /// Gets or sets the left.
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// Gets or sets the right.
            /// </summary>
            public Node Right { get; set; }
        }

        private class Node
        {
        }

        /// <summary>
        /// The Tree Node
        /// </summary>
        private class TreeNode : Node
        {
            /// <summary>
            /// Gets or sets the children.
            /// </summary>
            public List<Node> Children { get; set; }
        }

        private class UnaryNode : Node
        {
            /// <summary>
            /// Gets or sets the left.
            /// </summary>
            public string Data { get; set; }
        }
    }
}