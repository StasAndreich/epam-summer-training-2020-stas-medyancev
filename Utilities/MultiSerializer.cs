using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
        /// <summary>
        /// Serializes an object to a binary file.
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeToBinary(T @object, string filePath)
        {
            // Create a binary serializer of a specified type.
            var binFormatter = new BinaryFormatter();
            // Create and write to a binary file.
            var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            binFormatter.Serialize(fileStream, @object);
            fileStream.Close();
        }

        /// <summary>
        /// Serialize object to JSON file.
        /// </summary>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeToJson(T @object, string filePath)
        {
            // Create an JSON-serializer of specified type.
            var jsonStr = JsonConvert.SerializeObject(@object);
            // Create an JSON-file.
            var jsonFile = File.Create(filePath);
            // Write to JSON-file.
            using (var writer = new StreamWriter(jsonFile))
            {
                writer.Write(jsonStr);
            }
            jsonFile.Close();
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
                // Create an bin formatter.
                var binFormatter = new BinaryFormatter();
                
                // Check assembly versions.
                var binder = new MultiSerializerSerializationBinder();
                binFormatter.Binder = binder;

                // Read binary file.
                var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                // Create deserialized obj.
                var @object = (T)binFormatter.Deserialize(fileStream);
                fileStream.Close();

                return @object;
            }
            throw new FileNotFoundException("File does not exist.");
        }

        /// <summary>
        /// Deserialize object from JSON file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromJson(string filePath)
        {
            // Read JSON file.
            var file = File.OpenRead(filePath);
            // Create json string.
            var jsonStr = "";
            using (var reader = new StreamReader(file))
            {
                jsonStr = reader.ReadToEnd();
            }
            var @object = JsonConvert.DeserializeObject<T>(jsonStr);
            file.Close();

            return @object;
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


        #region ICollection methods.
        /// <summary>
        /// Serializes an ICollection`1 object to a binary file.
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeCollectionToBinary<TCollection>(TCollection @object, string filePath)
            where TCollection : ICollection<T>
        {
            // Create a binary serializer of a specified type.
            var binFormatter = new BinaryFormatter();

            // Create and write to a binary file.
            var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            binFormatter.Serialize(fileStream, @object);
            fileStream.Close();
        }

        /// <summary>
        /// Serialize an ICollection`1 object to JSON file.
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeCollectionToJson<TCollection>(TCollection @object, string filePath)
            where TCollection : ICollection<T>
        {
            // Create an JSON-serializer of specified type.
            var jsonStr = JsonConvert.SerializeObject(@object);
            // Create an JSON-file.
            var jsonFile = File.Create(filePath);
            // Write to JSON-file.
            using (var writer = new StreamWriter(jsonFile))
            {
                writer.Write(jsonStr);
            }
            jsonFile.Close();
        }

        /// <summary>
        /// Serializes an ICollection`1 object to an XML file.
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="object"></param>
        /// <param name="filePath"></param>
        public static void SerializeCollectionToXml<TCollection>(TCollection @object, string filePath)
            where TCollection : ICollection<T>
        {
            // Create an XML-serializer of specified type.
            var serializer = new XmlSerializer(typeof(TCollection));
            // Create an XML-file.
            var xmlFile = File.Create(filePath);
            // Write to XML-file.
            serializer.Serialize(xmlFile, @object);
            xmlFile.Close();
        }

        /// <summary>
        /// Deserializes an ICollection`1 object from the binary file.
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TCollection DeserializeCollectionFromBinary<TCollection>(string filePath)
            where TCollection : ICollection<T>
        {
            if (File.Exists(filePath))
            {
                // Create an bin formatter.
                var binFormatter = new BinaryFormatter();
                var binder = new MultiSerializerSerializationBinder();
                binFormatter.Binder = binder;

                // Read binary file.
                var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                // Create deserialized obj.
                var @object = (TCollection)binFormatter.Deserialize(fileStream);
                fileStream.Close();

                return @object;
            }
            throw new FileNotFoundException("File does not exist.");
        }

        /// <summary>
        /// Deserialize an ICollection`1 object from JSON file.
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TCollection DeserializeCollectionFromJson<TCollection>(string filePath)
            where TCollection : ICollection<T>
        {
            // Read JSON file.
            var file = File.OpenRead(filePath);
            // Create json string.
            var jsonStr = "";
            using (var reader = new StreamReader(file))
            {
                jsonStr = reader.ReadToEnd();
            }
            var @object = JsonConvert.DeserializeObject<TCollection>(jsonStr);
            file.Close();

            return @object;
        }

        /// <summary>
        /// Deserializes an ICollection`1 object from the XML file.
        /// </summary>
        /// <typeparam name="TCollection"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TCollection DeserializeCollectionFromXml<TCollection>(string filePath)
            where TCollection : ICollection<T>
        {
            if (File.Exists(filePath))
            {
                // Create an XML-deserializer of specified type.
                var deserializer = new XmlSerializer(typeof(TCollection));
                // Read XML-file.
                var file = new StreamReader(filePath);
                // Create deserialized obj.
                var @object = (TCollection)deserializer.Deserialize(file);
                file.Close();

                return @object;
            }
            throw new FileNotFoundException("File does not exist.");
        }
        #endregion
    }
}
