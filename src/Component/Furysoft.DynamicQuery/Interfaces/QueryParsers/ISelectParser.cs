// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISelectParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Interfaces.QueryParsers
{
    using Furysoft.DynamicQuery.Entities.QueryComponents;

    /// <summary>
    /// The Select Parser Interface.
    /// </summary>
    public interface ISelectParser
    {
        /// <summary>
        /// Parses the specified page data.
        /// </summary>
        /// <param name="selectData">The select data.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>The Page Node.</returns>
        SelectNode Parse(string selectData, char separator = ',');
    }
}