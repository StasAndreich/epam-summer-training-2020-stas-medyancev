using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class AssessmentRepository : Repository<Assessment>
    {
        public IQueryable<Assessment> GetAssessments()
        {
            return GetAll();
        }
    }
}
