using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class ExamRepository : Repository<Exam>,
        IExamRepository
    {
        public IQueryable<Exam> GetExams()
        {
            return GetAll();
        }
    }
}
