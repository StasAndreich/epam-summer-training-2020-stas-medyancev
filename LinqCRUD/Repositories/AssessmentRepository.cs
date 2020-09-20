using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class AssessmentRepository : Repository<Assessment>, 
        IAssessmentRepository
    {
        public IQueryable<Assessment> GetAssessments()
        {
            return GetAll();
        }
    }
}
