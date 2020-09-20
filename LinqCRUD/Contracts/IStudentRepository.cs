using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Repository for Student model.
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        /// <summary>
        /// Returns entity table.
        /// </summary>
        /// <returns></returns>
        IQueryable<Student> GetStudents();
    }
}
