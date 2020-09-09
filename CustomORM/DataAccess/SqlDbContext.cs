using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Describes an SQL database context.
    /// </summary>
    public class SqlDbContext : IDbContext
    {
        private static SqlDbContext context;
        private readonly IDbConnection connection;

        private SqlDbContext()
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["UniversityDBConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Creates and returns a database context.
        /// </summary>
        public static SqlDbContext Context
        {
            get
            {
                if (context == null)
                    context = new SqlDbContext();
                return context;
            }
        }

        /// <summary>
        /// Gets the string used to open the connection.
        /// </summary>
        public string ConnectionString => connection.ConnectionString;

        /// <summary>
        /// Gets a DB context.
        /// </summary>
        public IDbConnection Connection
        {
            get => context.connection;
        }
    }
}
