using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    public interface IExamDao : IDao<Exam>
    {
        IEnumerable<Exam> GetExams();
    }
}