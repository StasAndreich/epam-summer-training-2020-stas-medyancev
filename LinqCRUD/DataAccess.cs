using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;

namespace LinqCRUD
{
    public class DataAccess
    {
        private DataContext dataContext;

        public DataAccess()
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["UniversityDBExtendedConnection"].
                ConnectionString;
            dataContext = new DataContext(connectionString);
        }

        public IQueryable<>
    }
}
