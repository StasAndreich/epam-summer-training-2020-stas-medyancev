using System;
using AccessToDb.Contexts;
using AccessToDb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests_CustomORM
{
    [TestClass]
    public class UT_CRUD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dao = new GroupDAO();
            var group = dao.Get(1);
            var i = 5;
            dao.Remove(group);

        }
    }
}
