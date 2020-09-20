using System.Linq;

namespace LinqCRUD
{
    public interface IRepository<TModel> 
        where TModel : class
    {
        bool Save(TModel entity);
        bool Delete(int id);
        bool Delete(TModel entity);

        IQueryable<TModel> GetAll();
    }
}
