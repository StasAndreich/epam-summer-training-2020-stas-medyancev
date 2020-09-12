using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccessToDb.DAOs;
using AccessToDb;

namespace UnitTests_BusinessLogic
{
    [TestClass]
    public class UT_Xlsx
    {
        [TestMethod]
        public void TestMethod2()
        {
            //XlsxFilesCreator.CreateXslxResultsFile("file.xlsx");
            var m = new SessionManager(new DaoFactory());
            m.GetSessionResults();
        }
    }
}
