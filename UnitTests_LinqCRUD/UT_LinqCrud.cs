using LinqCRUD.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_LinqCRUD
{
    [TestClass]
    public class UT_LinqCrud
    {
        /// <summary>
        /// GetAll() methods tested only.
        /// No any Mock tests.
        /// </summary>

        #region GetAll()
        [TestMethod]
        public void GetAll_GroupRepository_GroupModel()
        {
            var repos = new GroupRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAll_AssessmentRepository_AssessmentModel()
        {
            var repos = new AssessmentRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAll_ExaminerRepository_ExaminerModel()
        {
            var repos = new ExaminerRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAll_ExamRepository_ExamModel()
        {
            var repos = new ExamRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAll_SpecialtyRepository_SpecialtyModel()
        {
            var repos = new SpecialtyRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAll_StudentRepository_StudentModel()
        {
            var repos = new StudentRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAll_SubjectRepository_SubjectModel()
        {
            var repos = new SubjectRepository();
            var models = repos.GetAll();

            // If there is no exceptions and models is
            // not null value.
            if (models != null)
                Assert.IsTrue(true);
            else Assert.IsTrue(false);
        }
        #endregion
    }
}
