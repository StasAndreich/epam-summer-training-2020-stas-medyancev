using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class ExaminerRepository : Repository<Examiner>
    {
        public IQueryable<Examiner> GetExaminers()
        {
            return GetAll();
        }
    }
}
