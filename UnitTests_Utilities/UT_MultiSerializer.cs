using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace UnitTests_Utilities
{
    [TestClass]
    public class UT_MultiSerializer
    {
        [TestMethod]
        public void SerializeToBinary_ISerializableClass_BinFile()
        {
            var sc = new ISerializableClass();
            sc.Name = "smth";
            sc.IntValue = 10;

            MultiSerializer<ISerializableClass>.SerializeToBinary(sc,
                "serToBin.bin");
        }

        [TestMethod]
        public void SerializeToJson_ISerializableClass_JsonFile()
        {
            var sc = new ISerializableClass();
            sc.Name = "smth";
            sc.IntValue = 10;

            MultiSerializer<ISerializableClass>.SerializeToJson(sc,
                "serToJson.json");
        }

        [TestMethod]
        public void SerializeToXml_ISerializableClass_XmlFile()
        {
            var sc = new ISerializableClass();
            sc.Name = "smth";
            sc.IntValue = 10;

            MultiSerializer<ISerializableClass>.SerializeToXml(sc,
                "serToXml.xml");
        }

        [TestMethod]
        public void DeserializeFromBinary_BinFile_ISerializableClass()
        {
            var expected = new ISerializableClass();
            expected.Name = "smth";
            expected.IntValue = 10;

            var serialized = 
                MultiSerializer<ISerializableClass>
                .DeserializeFromBinary("serToBin.bin");

            if (expected.Equals(serialized))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void DeserializeFromJson_JsonFile_ISerializableClass()
        {
            var expected = new ISerializableClass();
            expected.Name = "smth";
            expected.IntValue = 10;

            var serialized =
                MultiSerializer<ISerializableClass>
                .DeserializeFromJson("serToJson.json");

            if (expected.Equals(serialized))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void DeserializeFromXml_XmlFile_ISerializableClass()
        {
            var expected = new ISerializableClass();
            expected.Name = "smth";
            expected.IntValue = 10;

            var serialized =
                MultiSerializer<ISerializableClass>
                .DeserializeFromXml("serToXml.xml");

            if (expected.Equals(serialized))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
