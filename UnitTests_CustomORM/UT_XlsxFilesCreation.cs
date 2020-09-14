using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccessToDb.DAOs;
using AccessToDb;
using BusinessLogic;

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

            XlsxFilesCreator.CreateXlsxResultsFile("SessionResults.xlsx", m.GetSessionResults(new System.DateTime(2020, 01, 01),
                                       new System.DateTime(2020, 09, 01)));

            XlsxFilesCreator.CreateXlsxStatisticsFile("SessionStats.xlsx", m.GetSessionStatistics(new System.DateTime(2020, 01, 01),
                                       new System.DateTime(2020, 09, 01)));
        }
    }
}
