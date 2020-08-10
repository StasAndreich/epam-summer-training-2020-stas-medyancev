using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;

namespace UnitTests_BinaryTree
{
    [TestClass]
    public class UT_BinaryTree
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);


        }
    }
}
