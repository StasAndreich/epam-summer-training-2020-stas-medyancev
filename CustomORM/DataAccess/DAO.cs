using System;
using System.Collections.Generic;

namespace CustomORM.DataAccess
{
    /// <summary>
    /// Provides an access to a database table.
    /// </summary>
    public class DAO<TModel> : IDAO<TModel>
        where TModel : class
    {
        public void Create(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
