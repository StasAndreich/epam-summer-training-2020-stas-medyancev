using LinqCRUD.Models;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class AssessmentRepository : Repository<Assessment>
    {
        protected override Table<Assessment> GetTable()
        {
            return context.GetTable<Assessment>();
        }
    }
}
