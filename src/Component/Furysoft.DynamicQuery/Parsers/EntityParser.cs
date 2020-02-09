// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityParser.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.DynamicQuery.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Furysoft.DynamicQuery.Attributes;
    using Furysoft.DynamicQuery.Entities.Parsers;
    using Furysoft.DynamicQuery.Interfaces;

    /// <inheritdoc />
    public sealed class EntityParser<TEntity> : IEntityParser<TEntity>
    {
        /// <summary>
        /// The permitted properties.
        /// </summary>
        private List<EntityProperty> permittedProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityParser{TEntity}"/> class.
        /// </summary>
        public EntityParser()
        {
            this.PermittedProperties = this.GetProperties();
        }

        /// <summary>
        /// Gets the permitted properties.
        /// </summary>
        public List<EntityProperty> PermittedProperties
        {
            get => this.permittedProperties.Where(r => r.IsPermitted).ToList();

            private set => this.permittedProperties = value;
        }

        /// <summary>
        /// Determines whether the specified name is permitted.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if the specified name is permitted; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPermitted(string name)
        {
            return this.PermittedProperties.Any(r => r.IsPermitted && (r.InternalName == name || r.QueryName == name));
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>The list of property names.</returns>
        private List<EntityProperty> GetProperties()
        {
            var publicProperties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var rtn = new List<EntityProperty>();
            foreach (var propertyInfo in publicProperties)
            {
                var propertyName = propertyInfo.Name;
                var customName = propertyName;

                var nameAttributeName = propertyInfo.GetCustomAttribute<NameAttribute>(false);
                if (nameAttributeName != null)
                {
                    customName = nameAttributeName.Name;
                }

                var dataMemberName = propertyInfo.GetCustomAttribute<DataMemberAttribute>(false);
                if (dataMemberName != null)
                {
                    customName = dataMemberName.Name;
                }

                var isExcluded = Attribute.IsDefined(propertyInfo, typeof(ExcludeAttribute));

                var property = new EntityProperty
                {
                    InternalName = propertyName,
                    QueryName = customName,
                    IsPermitted = !isExcluded,
                };

                rtn.Add(property);
            }

            return rtn;
        }
    }
}