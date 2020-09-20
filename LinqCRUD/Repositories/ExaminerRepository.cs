using LinqCRUD.Models;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class ExaminerRepository : Repository<Examiner>
    {
        protected override Table<Examiner> GetTable()
        {
            return context.GetTable<Examiner>();
        }
    }
}
