using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>,
        ISpecialtyRepository
    {
        public IQueryable<Specialty> GetSpecialties()
        {
            return GetAll();
        }
    }
}
