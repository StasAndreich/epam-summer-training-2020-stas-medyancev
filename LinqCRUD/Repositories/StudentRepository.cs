using LinqCRUD.Contracts;
using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Repositories
{
    public class StudentRepository : Repository<Student>,
        IStudentRepository
    {
        public IQueryable<Student> GetStudents()
        {
            return GetAll();
        }
    }
}
