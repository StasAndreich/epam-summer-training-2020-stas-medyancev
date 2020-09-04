using System;
using System.Data;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public abstract class SqlDao<TModel> : IDao<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Returns a context connection to a DB.
        /// </summary>
        protected IDbConnection Context
        {
            get => SqlDbContext.Context;
        }

        /// <summary>
        /// Creates a new entity in its table.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TModel entity)
        {
            
        }

        /// <summary>
        /// Selects an entity by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TModel Get(int id)
        {
            // Get a table name.
            var tableName = DbNamesConverter.GetPluralName(typeof(TModel).Name);
            // Get fields names. (first or default)
            var cmd = $"SELECT * FROM {tableName} WHERE ";
        }

        public void Remove(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
