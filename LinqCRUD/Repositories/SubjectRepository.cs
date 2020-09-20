using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class SubjectRepository : Repository<Subject>
    {
        public IQueryable<Subject> GetSubjects()
        {
            return GetAll();
        }
    }
}
