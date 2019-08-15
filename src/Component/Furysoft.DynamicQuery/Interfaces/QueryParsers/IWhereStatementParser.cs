// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWhereStatementParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using Entities.Nodes;

    /// <summary>
    /// The Where Statement Parser
    /// </summary>
    public interface IWhereStatementParser
    {
        /// <summary>
        /// Parses the statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The <see cref="UnaryNode" />
        /// </returns>
        UnaryNode ParseStatement(string statement, string type = null);
    }
}