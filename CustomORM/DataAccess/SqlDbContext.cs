using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Describes an SQL database context.
    /// </summary>
    public class SqlDbContext : IDbContext
    {
        private static string connectionString = "";
        private static IDbConnection connection;

        private SqlDbContext()
        {
            ConnectionStringChanged += (sender, e) =>
            {
                connection = new SqlConnection(connectionString);
            };
        }        

        /// <summary>
        /// Fires when a connetion string changed.
        /// </summary>
        public static event EventHandler<PropertyChangedEventArgs> ConnectionStringChanged;
        /// <summary>
        /// Invokes a ConnectionStringChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected static void OnConnectionStringChanged(PropertyChangedEventArgs e)
        {
            var handler = ConnectionStringChanged;
            handler?.Invoke(typeof(SqlDbContext), e);
        }

        /// <summary>
        /// Gets or sets the string used to open the connection.
        /// </summary>
        public static string ConnectionString
        {
            get => connectionString;
            set
            {
                connectionString = value;
                OnConnectionStringChanged(new PropertyChangedEventArgs("ConnectionString"));
            }
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
