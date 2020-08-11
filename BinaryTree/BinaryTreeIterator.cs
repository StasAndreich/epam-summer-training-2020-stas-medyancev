using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    class BinaryTreeIterator<T> : IEnumerator<T>
        where T : IComparable<T>
    {
        List<T> nodes = new List<T>();
        int index;

        public BinaryTreeIterator(BinaryTreeNode<T> root)
        {
            index = -1;
            InorderTraverse(root);
        }

        public T Current
        {
            get
            {
                try
                {
                    return nodes[index];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        object IEnumerator.Current => nodes[index];

        private void InorderTraverse(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            InorderTraverse(node.LeftNode);
            nodes.Add(node.Data);
            InorderTraverse(node.RightNode);
        }

        public void Dispose()
        {
            nodes.Clear();
        }

        public bool MoveNext()
        {
            index++;
            return (index < nodes.Count);
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
