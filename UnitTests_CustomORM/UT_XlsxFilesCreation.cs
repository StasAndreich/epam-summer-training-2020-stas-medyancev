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
        public void CreateXlsxResultsFile_FilePathAndResults_XlsxFile()
        {
            var manager = new SessionManager(new DaoFactory());

            XlsxFilesCreator.CreateXlsxResultsFile("SessionResults.xlsx", 
                manager.GetSessionResults(new System.DateTime(2020, 01, 01),
                                       new System.DateTime(2020, 09, 01)));
            
            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxStatisticsFile_FilePathAndStats_XlsxFile()
        {
            var manager = new SessionManager(new DaoFactory());

            XlsxFilesCreator.CreateXlsxStatisticsFile("SessionStats.xlsx",
                manager.GetSessionStatistics(new System.DateTime(2020, 01, 01),
                                       new System.DateTime(2020, 09, 01)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CreateXlsxContributableStudentsFile_FilePathAndStudents_XlsxFile()
        {
            var manager = new SessionManager(new DaoFactory());

            XlsxFilesCreator.CreateXlsxContributableStudentsFile("ContributableStudents.xlsx",
                manager.GetContributableStudents(new System.DateTime(2020, 01, 01),
                                       new System.DateTime(2020, 09, 01)));

            // If no exceptions during file creation.
            Assert.IsTrue(true);
        }
    }
}
