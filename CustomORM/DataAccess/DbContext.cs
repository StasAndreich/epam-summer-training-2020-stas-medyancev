using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomORM.DataAccess
{
    public class DbContext
    {
        private static SqlConnection connection;

        private DbContext()
        {

        }

        public static SqlConnection GetConnection(string connectionString)
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
