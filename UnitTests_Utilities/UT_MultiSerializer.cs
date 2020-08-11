using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace UnitTests_Utilities
{
    [TestClass]
    public class UT_MultiSerializer
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sc = new ISerializableClass();
            sc.Name = "smth";
            sc.IntValue = 10;

            MultiSerializer<ISerializableClass>.SerializeToXml(sc, "");
        }
    }
}
