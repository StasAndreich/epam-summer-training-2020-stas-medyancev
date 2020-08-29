using System.Collections.Generic;
using CustomORM.DataAccess;
using AccessToDb.Models;

namespace AccessToDb.Contracts
{
    public interface IStudentDao : IDao<Student>
    {
        IEnumerable<Student> GetStudents();
    }
}