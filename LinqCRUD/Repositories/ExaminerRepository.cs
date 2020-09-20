using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class ExaminerRepository : Repository<Examiner>,
        IExaminerRepository
    {
        public IQueryable<Examiner> GetExaminers()
        {
            return GetAll();
        }
    }
}
