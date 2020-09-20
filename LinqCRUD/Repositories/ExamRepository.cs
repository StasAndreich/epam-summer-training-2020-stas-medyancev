using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class ExamRepository : Repository<Exam>
    {
        public IQueryable<Exam> GetExams()
        {
            return GetAll();
        }
    }
}
