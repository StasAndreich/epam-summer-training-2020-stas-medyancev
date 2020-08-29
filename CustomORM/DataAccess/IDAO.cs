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
        /// Entity insertion method.
        /// </summary>
        void Insert(TModel entity);
        /// <summary>
        /// Entity deletion method.
        /// </summary>
        void Delete(TModel entity);
        /// <summary>
        /// Submits all changes made to models.
        /// </summary>
        void SubmitChanges();
    }
}
