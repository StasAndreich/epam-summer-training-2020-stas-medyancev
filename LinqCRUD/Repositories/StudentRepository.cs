using LinqCRUD.Models;
using System.Data.Linq;

namespace LinqCRUD.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        protected override Table<Student> GetTable()
        {
            return context.GetTable<Student>();
        }
    }
}
