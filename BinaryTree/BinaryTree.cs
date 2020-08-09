using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// Defines a generic binary tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : ICollection, ICollection<T>
        where T : IComparable, IComparable<T>
    {
        /// <summary>
        /// Reference to a root node of the binary-tree.
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Adds data into the binary-tree.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        /// <summary>
        /// Adds a new node to the binary-tree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            // Current node (from which we start) here is 
            // a potential pointer to THIS node as a parent.
            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;

            var result = node.Data.CompareTo(currentNode.Data);
            if (result == 0)
            {
                return currentNode;
            }
            else
            {
                if (result < 0)
                {
                    if (currentNode.LeftNode == null)
                        return currentNode.LeftNode = node;
                    else
                        return Add(node, currentNode.LeftNode);
                }
                else
                {
                    if (currentNode.RightNode == null)
                        return currentNode.RightNode = node;
                    else
                        return Add(node, currentNode.RightNode);
                }
            }
        }
    }
}
