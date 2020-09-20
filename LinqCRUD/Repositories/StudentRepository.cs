using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public IQueryable<Student> GetStudents()
        {
            return GetAll();
        }
    }
}
