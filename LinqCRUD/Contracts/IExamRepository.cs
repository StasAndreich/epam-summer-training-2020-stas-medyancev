using LinqCRUD.Models;
using System.Linq;

namespace LinqCRUD.Contracts
{
    /// <summary>
    /// Repository for Exam model.
    /// </summary>
    public interface IExamRepository : IRepository<Exam>
    {
        /// <summary>
        /// Returns entity table.
        /// </summary>
        /// <returns></returns>
        IQueryable<Exam> GetExams();
    }
}
