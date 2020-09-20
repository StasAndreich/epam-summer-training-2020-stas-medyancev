using LinqCRUD.Models;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class SubjectRepository : Repository<Subject>
    {
        protected override Table<Subject> GetTable()
        {
            return context.GetTable<Subject>();
        }
    }
}
