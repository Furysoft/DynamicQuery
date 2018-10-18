// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhereSplitterTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests.Logic.Splitters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
            var testString1 = "test:value";
            var testString2 = "test:value and test2:value";
            var testString3 = "test:value and test2:value or test3:valuee";
            var testString4 = "test:value and test2:value or test3:value and test4:value";
            var testString5 = "test:value and test2:value or test3:value and test4:value and test5:value";
        //    var tree = ParseTree(testString1);
       //     var node = ParseTree(testString2);
       //     var tree1 = ParseTree(testString3);
       //     var tree2 = ParseTree(testString4);
            var tree3 = ParseTree(testString5);

            Print(tree3);
        }

        /// <summary>
        /// Prints the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="indent">The indent.</param>
        private static void Print(Node node, int indent = 0)
        {
            var s = new string(' ', indent * 4);

            if (node is UnaryNode unary)
            {
                Console.WriteLine($"{s}{unary.Data}");
            }

            if (node is BinaryNode binary)
            {
                Print(binary.Left);
                Print(binary.Right);
            }
        }

        /// <summary>
        /// Handles the split.
        /// </summary>
        /// <param name="stringPart">The string part.</param>
        /// <returns>
        /// The <see cref="Node" />
        /// </returns>
        private static Node ParseTree(string stringPart)
        {
            var matchCollection = RegexTest.Matches(stringPart);

            var midIndex = matchCollection.Count / 2;

            var strings = RegexTest.Split(stringPart, 2, midIndex + 1).ToList();

            // If there's only 1, we're done. No need to parse more!
            if (strings.Count == 1)
            {
                return new UnaryNode { Data = strings[0] };
            }

            return new BinaryNode
            {
                Left = ParseTree(strings[0]),
                Conjunctive = strings[1],
                Right = ParseTree(strings[2])
            };
        }

        /// <summary>
        /// Does the stuff.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="level">The level.</param>
        /// <returns>The <see cref="Node"/></returns>
        private Node ParseBrackets(string data, int level)
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

                        var doStuff = this.ParseBrackets(subQuery, level++);
                        children.Add(doStuff);

                        // Reset the leftBracket Index so that we can find any more bracket pairs at this level
                        leftBracketIndex = -1;
                    }
                }
            }

            if (!children.Any())
            {
                var tree = ParseTree(data);

                return null;
            }

            return new TreeNode
            {
                Children = children
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