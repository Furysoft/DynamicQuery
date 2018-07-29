// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Test.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class Test : TestBase
    {
        [Test]
        public void DoTest()
        {
            foreach (var s in Nested("(test:Fred) AND ((value:12) OR (4:5)) OR ((something:true) AND (somethingelse:false))"))
            {
                Console.WriteLine(s);
            }
        }

        private static IEnumerable<string> Nested(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                yield break; // or throw exception
            }

            var brackets = new Stack<int>();

            for (var i = 0; i < value.Length; ++i)
            {
                var ch = value[i];

                if (ch == '(')
                {
                    brackets.Push(i);
                }
                else if (ch == ')')
                {
                    //TODO: you may want to check if close ']' has corresponding open '['
                    // i.e. stack has values: if (!brackets.Any()) throw ...
                    var openBracket = brackets.Pop();

                    yield return value.Substring(openBracket + 1, i - openBracket - 1);
                }
            }

            //TODO: you may want to check here if there're too many '['
            // i.e. stack still has values: if (brackets.Any()) throw ...

            yield return value;
        }
    }
}