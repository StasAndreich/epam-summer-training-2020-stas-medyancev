using System.Linq;

namespace LinqCRUD
{
    /// <summary>
    /// Defines simple repository methods.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IRepository<TModel> 
        where TModel : class
    {
        /// <summary>
        /// Saves entity to a database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Save(TModel entity);

        /// <summary>
        /// Deletes entity from database by its instance.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(TModel entity);

        /// <summary>
        /// Gets all rows of a specified TModel entity
        /// as IQueryable generic type.
        /// </summary>
        /// <returns></returns>
        IQueryable<TModel> GetAll();
    }
}
