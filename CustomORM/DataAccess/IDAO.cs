using System.Collections.Generic;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Describes a data access object.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IDAO<TModel>
        where TModel : class
    {
        /// <summary>
        /// Entity creation method.
        /// </summary>
        void Create(TModel entity);
        /// <summary>
        /// Entity deletion method.
        /// </summary>
        void Delete(TModel entity);
        /// <summary>
        /// Entity upd method.
        /// </summary>
        void Update(TModel entity);

        /// <summary>
        /// Keeps DB rows by TModel type.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> GetData();
    }
}
