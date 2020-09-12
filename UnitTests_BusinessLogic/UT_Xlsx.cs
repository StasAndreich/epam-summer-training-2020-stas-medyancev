using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace UnitTests_BusinessLogic
{
    [TestClass]
    public class UT_Xlsx
    {
        [TestMethod]
        public void TestMethod1()
        {
            XlsxFilesCreator.CreateXslxResultsFile("file.xlsx");
        }
    }
}
