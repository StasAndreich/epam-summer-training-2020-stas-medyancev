using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Utilities
{
    /// <summary>
    /// Class that serializes T typed objects in
    /// different formats.
    /// </summary>
    /// <typeparam name="T">Serializable type.</typeparam>
    public class MultiSerializer<T>
        where T : ISerializable
    {
        //static MultiSerializer<T>()
        // Check for only class instanses in static ctor.

        /// <summary>
        /// Serializes an object to a binary file.
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeToBinary(T @object, string filePath)
        {
            // Create a binary serializer of a specified type.
            var serializer = new BinaryFormatter();
            // Create a binary file.
            var binFile = File.Create(filePath);
            // Write to binary file.
            serializer.Serialize(binFile, @object);
            binFile.Close();
        }

        public static void SerializeToJson(T @object, string filePath)
        {
            
        }

        /// <summary>
        /// Serializes an object to an XML file.
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeToXml(T @object, string filePath)
        {
            // Create an XML-serializer of specified type.
            var serializer = new XmlSerializer(typeof(T));
            // Create an XML-file.
            var xmlFile = File.Create(filePath);
            // Write to XML-file.
            serializer.Serialize(xmlFile, @object);
            xmlFile.Close();
        }

        /// <summary>
        /// Deserializes an object from the binary file.
        /// </summary>
        /// <param name="filePath"></param>
        public static T DeserializeFromBinary(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Create an binary deserializer of specified type.
                var deserializer = new BinaryFormatter();
                // Read binary file.
                var file = File.OpenRead(filePath);
                // Create deserialized obj.
                var @object = (T)deserializer.Deserialize(file);
                file.Close();

                return @object;
            }
            throw new FileNotFoundException("File does not exist.");
        }

        public static T DeserializeFromJson(string filePath)
        {

        }

        /// <summary>
        /// Deserializes an object from the XML file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Create an XML-deserializer of specified type.
                var deserializer = new XmlSerializer(typeof(T));
                // Read XML-file.
                var file = new StreamReader(filePath);
                // Create deserialized obj.
                var @object = (T)deserializer.Deserialize(file);
                file.Close();

                return @object;
            }
            throw new FileNotFoundException("File does not exist.");
        }
    }
}
