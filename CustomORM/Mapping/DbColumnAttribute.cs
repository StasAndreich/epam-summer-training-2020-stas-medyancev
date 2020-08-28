using System;

namespace CustomORM.Mapping
{
    /// <summary>
    /// Associates a class with a column in a database table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DbColumnAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the CustomORM.Mapping.DbColumnAttribute class.
        /// </summary>
        public DbColumnAttribute() { }

        /// <summary>
        /// Gets or sets the name of a column.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets whether this class member represents a column 
        /// that is part or all of the primary key of the table.
        /// </summary>
        /// <returns>Default = false.</returns>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// Gets or sets whether a column can contain null values.
        /// </summary>
        /// <returns>Default = true.</returns>
        public bool CanBeNull { get; set; } = true;
    }
}
