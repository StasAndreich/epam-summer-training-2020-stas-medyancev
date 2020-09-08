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
        private static string connectionString;
        private static IDbConnection connection;
        private static SqlDbContext context;

        private SqlDbContext()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["UniversityDBConnection"].ConnectionString;
        }

        /// <summary>
        /// Gets or sets the string used to open the connection.
        /// </summary>
        public static string ConnectionString
        {
            get => connectionString;
            set => connectionString = value;
        }

        /// <summary>
        /// Holds a context connection.
        /// </summary>
        public static IDbConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new SqlConnection(connectionString);
                return connection;
            }
        }
    }
}
