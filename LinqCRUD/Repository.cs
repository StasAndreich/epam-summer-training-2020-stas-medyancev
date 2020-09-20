using System.Configuration;
using System.Data.Linq;
using System.Linq;

namespace LinqCRUD
{
    /// <summary>
    /// Defines a repository class that uses LINQ to SQL.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class Repository<TModel> : IRepository<TModel>
        where TModel : class
    {
        /// <summary>
        /// Data context.
        /// </summary>
        protected readonly DataContext context = 
            new DataContext(ConfigurationManager.
                ConnectionStrings["UniversityDBExtendedConnection"].
                ConnectionString);

        /// <summary>
        /// Deletes entity from database by its instance.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Delete(TModel entity)
        {
            GetTable().DeleteOnSubmit(entity);
            context.SubmitChanges();
        }

        /// <summary>
        /// Gets all rows of a specified TModel entity
        /// as IQueryable generic type.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TModel> GetAll()
        {
            return GetTable().AsQueryable();
        }

        /// <summary>
        /// Saves entity to a database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Save(TModel entity)
        {
            GetTable().InsertOnSubmit(entity);
            context.SubmitChanges();
        }

        /// <summary>
        /// Returns table of a specified TModel type.
        /// </summary>
        /// <returns></returns>
        protected abstract Table<TModel> GetTable();
    }
}
