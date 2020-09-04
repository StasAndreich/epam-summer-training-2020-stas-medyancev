using System.Data;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Defines a database context.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Returns a database connection.
        /// </summary>
        IDbConnection Context { get; }
    }
}
