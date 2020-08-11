using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BinaryTree
{
    /// <summary>
    /// Defines a generic self-balancing binary tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Reference to a root node of the binary-tree.
        /// </summary>
        public BinaryTreeNode<T> rootNode;

        /// <summary>
        /// Returns binary tree nodes count.
        /// </summary>
        public int Count
        {
            get
            {
                var i = 0;
                foreach (var node in this)
                    i++;
                return i;
            }
        }

        /// <summary>
        /// Adds a node into a specific subtree.
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> startNode, T data)
        {
            if (startNode == null)
                return new BinaryTreeNode<T>(data);

            if (data.CompareTo(startNode.Data) <= -1)
                startNode.LeftNode = Add(startNode.LeftNode, data);
            else
                startNode.RightNode = Add(startNode.RightNode, data);

            return startNode.Balance();
        }

        /// <summary>
        /// Adds data to a binary tree (from the root node).
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Add(T data)
        {
            // If the root exists.
            if (rootNode != null)
                return Add(rootNode, data);
            // If the root is null.
            else
                return rootNode = new BinaryTreeNode<T>(data);
        }

        /// <summary>
        /// Finds the minimum node in a specific subtree.
        /// </summary>
        /// <param name="subtreeRoot"></param>
        /// <returns></returns>
        public static BinaryTreeNode<T> FindMinNode(BinaryTreeNode<T> subtreeRoot)
        {
            return (subtreeRoot.LeftNode != null) 
                ? FindMinNode(subtreeRoot.LeftNode) 
                : subtreeRoot;
        }

        private BinaryTreeNode<T> RemoveMinNode(BinaryTreeNode<T> node)
        {
            if (node.LeftNode == null)
                return node.RightNode;

            node.LeftNode = RemoveMinNode(node.LeftNode);
            return node.Balance();
        }

        /// <summary>
        /// Removes a node with specified data from
        /// a parameter subtree. No exceptions occured.
        /// </summary>
        /// <param name="subtreeRoot"></param>
        /// <param name="data"></param>
        /// <returns>Tree without removed node.</returns>
        public BinaryTreeNode<T> TryRemove(BinaryTreeNode<T> subtreeRoot, T data)
        {
            if (subtreeRoot == null) return null;

            if (data.CompareTo(subtreeRoot.Data) <= -1)
                subtreeRoot.LeftNode = TryRemove(subtreeRoot.LeftNode, data);
            else if (data.CompareTo(subtreeRoot.Data) >= 1)
                subtreeRoot.RightNode = TryRemove(subtreeRoot.RightNode, data);
            // In case of data equality. 
            else
            {
                var left = subtreeRoot.LeftNode;
                var right = subtreeRoot.RightNode;
                // Null to subtree.
                subtreeRoot = null;

                if (right == null) return right;
                var min = FindMinNode(right);
                min.RightNode = RemoveMinNode(right);
                min.LeftNode = left;
                return min.Balance();
            }

            return subtreeRoot.Balance();
        }

        /// <summary>
        /// Removes a node from a tree.
        /// </summary>
        /// <param name="data"></param>
        public void Remove(T data)
        {
            rootNode = TryRemove(rootNode, data);
        }

        /// <summary>
        /// Serializes this binary tree to an XML-file.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="filePath"></param>
        public static void SerializeToXml(BinaryTree<T> tree, string filePath)
        {
            // Create an XML-serializer of a tree type.
            var serializer = new XmlSerializer(typeof(BinaryTree<T>));
            // Create an XML-file.
            var xmlFile = File.Create(filePath);
            // Write to XML-file.
            serializer.Serialize(xmlFile, tree);
            xmlFile.Close();
        }

        /// <summary>
        /// Deserializes a binary tree from an XML-file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static BinaryTree<T> DeserializeFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Create an XML-deserializer of a tree type.
                var deserializer = new XmlSerializer(typeof(BinaryTree<T>));
                // Read XML-file.
                var file = new StreamReader(filePath);
                // Create deserialized tree.
                var @object = deserializer.Deserialize(file);
                file.Close();

                return (BinaryTree<T>)@object;
            }
            throw new FileNotFoundException("File does not exist.");
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var iterator = new BinaryTreeIterator<T>(rootNode);
            while(iterator.MoveNext())
            {
                yield return iterator.Current; 
            }
        }


        #region Overrides
        /// <summary>
        /// Returns a result of ToString() of the node data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (var node in this)
            {
                str.Append(node.ToString());
            }
            return str.ToString();
        }

        /// <summary>
        /// Check the equality of this tree node
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var tree = (BinaryTree<T>)obj;

            // Create lists for tree data.
            var thisList = new List<T>();
            var treeList = new List<T>();

            // Get all the data from trees to a list.
            foreach (var node in tree)
                treeList.Add(node);

            foreach (var node in this)
                thisList.Add(node);

            // Compare two lists.
            if (thisList.Count != treeList.Count)
                return false;

            bool result = true;
            for (int i = 0; i < this.Count; i++)
            {
                if (!treeList[i].Equals(thisList[i]))
                    result = false;
            }
            return result;
        }

        /// <summary>
        /// Returns a hash-code for a tree node object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = rootNode.GetHashCode();
            foreach (var node in this)
                hash ^= node.GetHashCode();

            return hash;
        }
        #endregion
    }
}
