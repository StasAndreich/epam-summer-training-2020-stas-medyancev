using System;
using System.Data.SqlClient;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public abstract class ModelDao<TModel> : IDao<TModel>
        where TModel : class, new()
    {
        protected SqlConnection Context
        {
            get => DbContextManager.Context;
        }

        public void Insert(TModel entity)
        {
            
        }

        public void Delete(TModel entity)
        {
            throw new NotImplementedException();
        }        

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
