using System;

namespace CustomORM.Mapping
{
    /// <summary>
    /// Designates a class as an entity class that is associated with a database table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DbTableAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the CustomORM.Mapping.DbTableAttribute class.
        /// </summary>
        /// <param name="tableName"></param>
        public DbTableAttribute(string tableName) 
        {
            Name = tableName;
        }

        /// <summary>
        /// Gets or sets the name of the table or view.
        /// </summary>
        public string Name { get; set; }
    }
}
