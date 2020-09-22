using System;
using System.Linq;
using BusinessLogicUsingLinq;
using LinqCRUD.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_LinqCRUD
{
    [TestClass]
    public class UT_XlsxFiles
    {
        [TestMethod]
        public void CreateXlsxSpecialtyStatistics_FilePathAndStatsByAvgMark_XlsxFile()
        {
            var manager = new SessionManager(new RepositoryFactory());

            XlsxCreator.CreateXlsxSpecialtyStatistics("SpecialtyStatistics.xlsx",
                manager.GetSpecialtyStatistics(new DateTime(2020, 01, 01),
                                       new DateTime(2020, 09, 01),
                                       results => results.
                                       OrderBy(r => r.AvgMark)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxExaminerStatistics_FilePathAndStatsByAvgMark_XlsxFile()
        {
            var manager = new SessionManager(new RepositoryFactory());

            XlsxCreator.CreateXlsxExaminerStatistics("ExaminerStatistics.xlsx",
                manager.GetExaminerStatistics(new DateTime(2020, 01, 01),
                                       new DateTime(2020, 09, 01),
                                       results => results.
                                       OrderBy(r => r.AvgMark)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxSubjectMarkDynamics_FilePathAndSubjectAvgMarkByYears_XlsxFile()
        {
            var manager = new SessionManager(new RepositoryFactory());
            var subjMark = manager.GetSubjectAvgMarkByYears();

            XlsxCreator.CreateXlsxSubjectMarkDynamics("SubjectMarkDynamics.xlsx",
                subjMark);

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxResults_FilePathAndResultsSortedBySurname_XlsxFile()
        {
            var manager = new SessionManager(new RepositoryFactory());

            XlsxCreator.CreateXlsxResults("SessionResults.xlsx",
                manager.GetSessionResults(new DateTime(2020, 01, 01),
                                       new DateTime(2020, 09, 01),
                                       results => results.
                                       OrderBy(r => r.StudentSurname)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxStatistics_FilePathAndStatsSortedByGroupName_XlsxFile()
        {
            var manager = new SessionManager(new RepositoryFactory());

            XlsxCreator.CreateXlsxStatistics("SessionStats.xlsx",
                manager.GetSessionStatistics(new DateTime(2020, 01, 01),
                                       new DateTime(2020, 09, 01),
                                       stats => stats.
                                       OrderBy(s => s.GroupName)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxContributableStudentsFile_FilePathAndStudentsSortedBySurname_XlsxFile()
        {
            var manager = new SessionManager(new RepositoryFactory());

            XlsxCreator.CreateXlsxContributableStudents("ContributableStudents.xlsx",
                manager.GetContributableStudents(new DateTime(2020, 01, 01),
                                       new DateTime(2020, 09, 01),
                                       students => students.
                                       OrderBy(s => s.Surname)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }
    }
}
