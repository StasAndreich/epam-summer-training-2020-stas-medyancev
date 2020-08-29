using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    public interface ISubjectDao : IDao<Subject>
    {
        IEnumerable<Subject> GetSubjects();
    }
}