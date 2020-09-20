using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;

namespace LinqCRUD
{
    public abstract class Repository<TModel> : IRepository<TModel>
        where TModel : class
    {
        protected readonly DataContext context = 
            new DataContext(ConfigurationManager.
                ConnectionStrings["UniversityDBExtendedConnection"].
                ConnectionString);

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TModel entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(TModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
