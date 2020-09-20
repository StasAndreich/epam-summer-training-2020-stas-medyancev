using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class SubjectRepository : Repository<Subject>,
        ISubjectRepository
    {
        public IQueryable<Subject> GetSubjects()
        {
            return GetAll();
        }
    }
}
