using System;
using System.Collections.Generic;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public abstract class Dao<TModel> : IDao<TModel>
        where TModel : class
    {
        public void Delete(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
