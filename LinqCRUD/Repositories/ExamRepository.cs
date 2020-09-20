using LinqCRUD.Models;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class ExamRepository : Repository<Exam>
    {
        protected override Table<Exam> GetTable()
        {
            return context.GetTable<Exam>();
        }
    }
}
