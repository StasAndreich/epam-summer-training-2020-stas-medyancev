using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using System.Runtime.Serialization;
using System.Collections.Generic;
using InformationTypes;
using TR = InformationTypes.TestResult;
using System.Threading;

namespace UnitTests_BinaryTree
{
    [TestClass]
    public class UT_BinaryTree
    {
        [TestMethod]
        public void Add_Int32Values_TreeCorrectlyInitializedAndBalanced()
        {
            var tree = new BinaryTree<int>();
            var expectedList = new List<int>();
            expectedList.Add(2);
            expectedList.Add(5);
            expectedList.Add(7);
            expectedList.Add(8);
            expectedList.Add(9);

            var treeList = new List<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(8);
            tree.Add(9);

            // Parse tree to a list.
            foreach (var node in tree)
                treeList.Add(node);

            bool result = true;
            for (int i = 0; i < expectedList.Count; i++)
            {
                if (!treeList[i].Equals(expectedList[i]))
                    result = false;
            }
            // If no exceptions occured.
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Add_TestResultValues_TreeCorrectlyInitializedAndBalanced()
        {
            var tree = new BinaryTree<TR>();
            var tr1 = new TR("A", new Student("A", "B"), DateTime.Today, 5);
            var tr2 = new TR("A", new Student("A", "B"), DateTime.Today, 2);
            var tr3 = new TR("A", new Student("A", "B"), DateTime.Today, 7);
            var tr4 = new TR("A", new Student("A", "B"), DateTime.Today, 8);
            var tr5 = new TR("A", new Student("A", "B"), DateTime.Today, 9);

            var expectedList = new List<TR>();
            expectedList.Add(tr2);
            expectedList.Add(tr1);
            expectedList.Add(tr3);
            expectedList.Add(tr4);
            expectedList.Add(tr5);

            var treeList = new List<TR>();
            tree.Add(tr1);
            tree.Add(tr2);
            tree.Add(tr3);
            tree.Add(tr4);
            tree.Add(tr5);

            // Parse tree to a list.
            foreach (var node in tree)
                treeList.Add(node);

            bool result = true;
            for (int i = 0; i < expectedList.Count; i++)
            {
                if (!treeList[i].Equals(expectedList[i]))
                    result = false;
            }
            // If no exceptions occured.
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_Int32Values_TreeCorrectlyBalanced()
        {
            var tree = new BinaryTree<int>();
            var expectedList = new List<int>();
            expectedList.Add(2);
            expectedList.Add(5);
            expectedList.Add(7);
            expectedList.Add(9);

            var treeList = new List<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(8);
            tree.Add(9);

            // Remove a node.
            tree.Remove(8);

            // Parse tree to a list.
            foreach (var node in tree)
                treeList.Add(node);

            bool result = true;
            for (int i = 0; i < expectedList.Count; i++)
            {
                if (!treeList[i].Equals(expectedList[i]))
                    result = false;
            }
            // If no exceptions occured.
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_TestResultValues_TreeCorrectlyBalanced()
        {
            var tree = new BinaryTree<TR>();
            var tr1 = new TR("A", new Student("A", "B"), DateTime.Today, 5);
            var tr2 = new TR("A", new Student("A", "B"), DateTime.Today, 2);
            var tr3 = new TR("A", new Student("A", "B"), DateTime.Today, 7);
            var tr4 = new TR("A", new Student("A", "B"), DateTime.Today, 8);
            var tr5 = new TR("A", new Student("A", "B"), DateTime.Today, 9);

            var expectedList = new List<TR>();
            expectedList.Add(tr2);
            expectedList.Add(tr1);
            expectedList.Add(tr3);
            expectedList.Add(tr5);

            var treeList = new List<TR>();
            tree.Add(tr1);
            tree.Add(tr2);
            tree.Add(tr3);
            tree.Add(tr4);
            tree.Add(tr5);

            // Remove a node.
            tree.Remove(tr4);

            // Parse tree to a list.
            foreach (var node in tree)
                treeList.Add(node);

            bool result = true;
            for (int i = 0; i < expectedList.Count; i++)
            {
                if (!treeList[i].Equals(expectedList[i]))
                    result = false;
            }
            // If no exceptions occured.
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SerializeToXml_InitializedTreeTestResult_XmlFile()
        {
            var tr1 = new TR("A", new Student("A", "B"), DateTime.Today, 5);
            var tr2 = new TR("A", new Student("A", "B"), DateTime.Today, 2);
            var tr3 = new TR("A", new Student("A", "B"), DateTime.Today, 7);
            var tr4 = new TR("A", new Student("A", "B"), DateTime.Today, 8);
            var tr5 = new TR("A", new Student("A", "B"), DateTime.Today, 9);
            
            var tree = new BinaryTree<TR>();
            tree.Add(tr1);
            tree.Add(tr2);
            tree.Add(tr3);
            tree.Add(tr4);
            tree.Add(tr5);

            BinaryTree<TR>.SerializeToXml(tree, "testTestResult.xml");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeserializeToXml_XmlFile_InitializedTreeTestResult()
        {
            var tr1 = new TR("A", new Student("A", "B"), DateTime.Today, 5);
            var tr2 = new TR("A", new Student("A", "B"), DateTime.Today, 2);
            var tr3 = new TR("A", new Student("A", "B"), DateTime.Today, 7);
            var tr4 = new TR("A", new Student("A", "B"), DateTime.Today, 8);
            var tr5 = new TR("A", new Student("A", "B"), DateTime.Today, 9);

            var expectedTree = new BinaryTree<TR>();
            expectedTree.Add(tr1);
            expectedTree.Add(tr2);
            expectedTree.Add(tr3);
            expectedTree.Add(tr4);
            expectedTree.Add(tr5);

            var deserializedTree = BinaryTree<TR>.DeserializeFromXml("testTestResult.xml");

            if (expectedTree.Equals(deserializedTree))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
