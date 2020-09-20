using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>
    {
        public IQueryable<Specialty> GetSpecialties()
        {
            return GetAll();
        }
    }
}
