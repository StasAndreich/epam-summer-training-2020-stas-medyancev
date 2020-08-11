using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using System.Runtime.Serialization;

namespace UnitTests_BinaryTree
{
    [TestClass]
    public class UT_BinaryTree
    {
        [Serializable]
        public class My : IComparable<My>
        {
            public int age;
            public My()
            {

            }

            public My(int a)
            {
                age = a;
            }

            public int CompareTo(My obj)
            {
                // If other is not a valid object reference, 
                // this instance is greater.
                if (obj == null) return 1;
                // If objects are equal they are same.
                if (this.Equals(obj)) return 0;

                return this.age.CompareTo(obj.age);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            //var o = new My();

            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(8);
            tree.Add(9);

            //tree.Add(new My(5));
            //tree.Add(new My(2));
            //tree.Add(new My(7));
            //tree.Add(new My(8));
            //tree.Add(new My(9));
            
            //BinaryTree<My>.SerializeToXml(tree, "test.xml");
            tree.rootNode = tree.TryRemove(tree.rootNode, 8);
            int r = 5;
            //var str = BinaryTree<int>.FindMinNode(tree.RootNode);
            //Assert.AreEqual(str.ToString(), 2.ToString());

            //var tree = BinaryTree<My>.DeserializeFromXml("test.xml");
            //int a = 5;
        }
    }
}
