using System.Data;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Defines a database context.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Provides a connection to a database.
        /// </summary>
        IDbConnection Connection { get; }
    }
}
