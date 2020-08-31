using System;
using System.ComponentModel;
using System.Data.SqlClient;

namespace CustomORM.DataAccess
{
    public class DbContextManager
    {
        private DbContextManager()
        {
            ConnectionStringChanged += (sender, e) =>
            {
                if (connection != null)
                    connection = new SqlConnection(connectionString);
            };
        }

        private static string connectionString = "";
        private static SqlConnection connection;

        public static event EventHandler<PropertyChangedEventArgs> ConnectionStringChanged;
        protected static void OnConnectionStringChanged(PropertyChangedEventArgs e)
        {
            var handler = ConnectionStringChanged;
            handler?.Invoke(typeof(DbContextManager), e);
        }

        public static string ConnectionString
        {
            get => connectionString;
            set
            {
                connectionString = value;
                OnConnectionStringChanged(new PropertyChangedEventArgs("ConnectionString"));
            }
        }

        public static SqlConnection Context
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
