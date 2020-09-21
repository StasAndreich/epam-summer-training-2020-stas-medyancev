using System.Configuration;
using System.Data.Linq;

namespace LinqCRUD
{
    /// <summary>
    /// Describes an Linq to SQL database context.
    /// </summary>
    public class RepositoryContext
    {
        private static RepositoryContext context;
        private readonly DataContext data;

        private RepositoryContext()
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["UniversityDBExtendedConnection"].
                ConnectionString;
            data = new DataContext(connectionString);
        }

        /// <summary>
        /// Creates and returns a database context.
        /// </summary>
        public static DataContext Context
        {
            get
            {
                if (context == null)
                    context = new RepositoryContext();
                return context.data;
            }
        }
    }
}
