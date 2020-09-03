namespace CustomORM.DataAccess
{
    /// <summary>
    /// Describes a data access object.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IDao<TModel>
        where TModel : class
    {
        /// <summary>
        /// Entity selection method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TModel Get(int id);
        /// <summary>
        /// Entity updation method.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TModel entity);
        /// <summary>
        /// Entity insertion method.
        /// </summary>
        void Add(TModel entity);
        /// <summary>
        /// Entity deletion method.
        /// </summary>
        void Remove(TModel entity);
    }
}
