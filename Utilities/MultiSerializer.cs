using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilities
{
    public class MultiSerializer<T>
        where T : ISerializable
    {
        //static MultiSerializer<T>()
            
        public static void SerializeToBinary(T @object)
        {

        }

        public static void SerializeToJson(T @object)
        {

        }

        public static void SerializeToXml(T @object)
        {

        }

        public static void DeserializeFromBinary(string filePath)
        {

        }

        public static void DeserializeFromJson(string filePath)
        {

        }

        public static void DeserializeFromXml(string filePath)
        {

        }

        private static MemoryStream SerializeToMemory(T objGraph)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            // Serialize input object.
            formatter.Serialize(stream, objGraph);
            
            return stream;
        }

        private static T DeserializeFromMemory(Stream stream)
        {
            // Set formatting.
            var formatter = new BinaryFormatter();
            // Deserialize.
            formatter.Deserialize(stream);
        }

    }
}
