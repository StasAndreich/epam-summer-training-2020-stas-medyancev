using System;
using AccessToDb.Contexts;
using AccessToDb.DAOs;
using AccessToDb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_CustomORM
{
    [TestClass]
    public class UT_CRUD
    {
        #region Get(int id)
        [TestMethod]
        public void Get_GroupDAO_GroupModelById()
        {
            var dao = new GroupDAO();
            var model = dao.Get(1);
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Get_SubjectDAO_SubjectModelById()
        {
            var dao = new SubjectDAO();
            var model = dao.Get(1);
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Get_AssessmentDAO_AssessmentModelById()
        {
            var dao = new AssessmentDAO();
            var model = dao.Get(1);
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Get_ExamDAO_ExamModelById()
        {
            var dao = new ExamDAO();
            var model = dao.Get(1);
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Get_StudentDAO_StudentModelById()
        {
            var dao = new StudentDAO();
            var model = dao.Get(1);
            // If there is no exceptions.
            Assert.IsTrue(true);
        }
        #endregion

        #region GetAll()
        [TestMethod]
        public void GetAll_GroupDAO_GroupModels()
        {
            var dao = new GroupDAO();
            var groups = dao.GetAll();
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAll_SubjectDAO_SubjectModels()
        {
            var dao = new SubjectDAO();
            var subjects = dao.GetAll();
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAll_AssessmentDAO_AssessmentModels()
        {
            var dao = new AssessmentDAO();
            var assessments = dao.GetAll();
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAll_ExamDAO_ExamModels()
        {
            var dao = new ExamDAO();
            var exams = dao.GetAll();
            // If there is no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAll_StudentDAO_StudentModels()
        {
            var dao = new StudentDAO();
            var students = dao.GetAll();
            // If there is no exceptions.
            Assert.IsTrue(true);
        } 
        #endregion
    }
}
